﻿using Dora.Interception;

namespace App
{
    public interface ISystemTimeProvider
    {
        DateTime GetCurrentTime(DateTimeKind kind);
    }
    public class SystemTimeProvider : ISystemTimeProvider
    {
        public virtual DateTime GetCurrentTime(DateTimeKind kind) => kind switch
        {
            DateTimeKind.Utc => DateTime.UtcNow,
            _ => DateTime.Now
        };
    }
}