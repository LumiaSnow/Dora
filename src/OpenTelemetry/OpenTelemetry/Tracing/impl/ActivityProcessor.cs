﻿using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System.Buffers;
using System.Diagnostics;
using System.Threading.Channels;

namespace Dora.OpenTelemetry.Tracing
{
    internal class ActivityProcessor : IActivityProcessor
    {
        private readonly Action<Activity> _startHandler;
        private readonly Action<Activity> _stopHandler;

        public ActivityProcessor(
            IOptions<TracingOptions> optionsAccessor, 
            IEnumerable<IActivityHandler> handlers,
            IEnumerable<IActivityExporter> exporters,
            ILogger<ActivityProcessor> logger)
        {
            Guard.ArgumentNotNull(optionsAccessor);
            Guard.ArgumentNotNull(handlers);
            Guard.ArgumentNotNull(exporters);
            Guard.ArgumentNotNull(logger);

            var options = (optionsAccessor ?? throw new ArgumentNullException(nameof(optionsAccessor))).Value.Batching;
            var channel = Channel.CreateUnbounded<PooledActivityCollection>();
            _startHandler = CreateStartHandler(handlers);
            _stopHandler = CreateStopHandler(handlers, channel, options, logger);
            StartConsumeActivities(channel, exporters);
        }

        public void OnActivityStarted(Activity activity) => _startHandler(activity);

        public void OnActivityStopped(Activity activity) => _stopHandler(activity);

        private static Action<Activity> CreateStartHandler(IEnumerable<IActivityHandler> handlers)
        {
            var handlerArray = handlers.ToArray();
            var handlerCount = handlerArray.Length;
            var singleHandler = handlerArray.FirstOrDefault();
            return handlerArray.Length switch
            {
                0 => _ => { },
                1 => a => singleHandler!.OnActivityStarted(a),
                _ => a =>
                {
                    for (int index = 0; index < handlerCount; index++)
                    {
                        handlerArray[index].OnActivityStarted(a);
                    }
                }
            };
        }

        private static Action<Activity> CreateStopHandler(
            IEnumerable<IActivityHandler> handlers, 
            Channel<PooledActivityCollection> processChannel,
            BatchingOptions options, 
            ILogger<ActivityProcessor> logger)
        {
            var handlerArray = handlers.ToArray();
            var handlerCount = handlerArray.Length;
            var singleHandler = handlerArray.FirstOrDefault();
            var log4BufferOverflow = LoggerMessage.Define(LogLevel.Warning, 0, "Activity buffer overflow, and the specified activity will be discarded.");
            var writer = processChannel.Writer;
            var deliverer = new BatchDeliverer<Activity>(options.BufferCapacity, options.BatchSize, options.CheckInterval, options.DeliveryInterval, QueueActivities);

            return handlerArray.Length switch
            {
                0 => a =>
                {
                    if (!deliverer.TryEnqueue(a))
                    {
                        log4BufferOverflow(logger, null!);
                    }
                },
                1 => a => {
                    singleHandler!.OnActivityStopped(a);
                    if (!deliverer.TryEnqueue(a))
                    {
                        log4BufferOverflow(logger, null!);
                    }
                },
                _ => a =>
                {
                    for (int index = handlerCount -1; index > -1; index--)
                    {
                        handlerArray[index].OnActivityStopped(a);
                    }
                    if (!deliverer.TryEnqueue(a))
                    {
                        log4BufferOverflow(logger, null!);
                    }
                }
            };

            void QueueActivities(Memory<Activity>? firstBatch, Memory<Activity>? sencondBatch)
            {
                var segment = new PooledActivityCollection(options.BatchSize, firstBatch, sencondBatch);
                if (!writer.TryWrite(segment))
                {
                    writer.WriteAsync(segment).AsTask().GetAwaiter().GetResult();
                }
            }
        }

        private static void StartConsumeActivities(Channel<PooledActivityCollection> processChannel, IEnumerable<IActivityExporter> exporters)
        {
            var count = exporters.Count();
            var singleExporter = count <= 1 ? exporters.SingleOrDefault() : null;
            var exporterChannels = count > 1 ? exporters.ToDictionary(it => it, it => Channel.CreateUnbounded<PooledActivityCollection>()) : null;
            var processReader = processChannel.Reader;
            if (exporterChannels is null)
            {
                Task.Factory.StartNew(() =>
                {
                    while (true)
                    {
                        if (processReader.TryRead(out var collection))
                        {
                            try
                            {
                                singleExporter?.Export(collection.Activities);
                            }
                            finally
                            {
                                collection.Dispose();
                            }
                        }
                        else
                        {
                            processReader.WaitToReadAsync().AsTask().Wait();
                        }

                    }
                }, TaskCreationOptions.LongRunning);
            }
            else
            {
                Task.Factory.StartNew(() =>
                {
                    while (true)
                    {
                        if (processReader.TryRead(out var collection))
                        {
                            foreach (var kv in exporterChannels)
                            {
                                var writer = kv.Value.Writer;
                                if (!writer.TryWrite(collection))
                                {
                                    writer.WriteAsync(collection).AsTask().GetAwaiter().GetResult();
                                }
                            }
                        }
                        else
                        {
                            processReader.WaitToReadAsync().AsTask().Wait();
                        }
                    }
                }, TaskCreationOptions.LongRunning);

                foreach (var item in exporterChannels)
                {                    
                    Task.Factory.StartNew(state =>
                    {
                        var kv = (KeyValuePair<IActivityExporter, Channel<PooledActivityCollection>>)state!;
                        var exporter = kv.Key;
                        var reader = kv.Value.Reader;
                        while (true)
                        {
                            if (processReader.TryRead(out var collection))
                            {
                                try
                                {
                                    exporter.Export(collection.Activities);
                                }
                                finally
                                {
                                    collection.Dispose();
                                }
                            }
                            else
                            {
                                processReader.WaitToReadAsync().AsTask().Wait();
                            }

                        }
                    },item, TaskCreationOptions.LongRunning);
                }
            }
        }
    }
}
