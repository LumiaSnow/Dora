﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Dora.Interception.Properties {
    using System;
    
    
    /// <summary>
    ///   A strongly-typed resource class, for looking up localized strings, etc.
    /// </summary>
    // This class was auto-generated by the StronglyTypedResourceBuilder
    // class via a tool like ResGen or Visual Studio.
    // To add or remove a member, edit your .ResX file then rerun ResGen
    // with the /str option, or rebuild your VS project.
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Resources.Tools.StronglyTypedResourceBuilder", "16.0.0.0")]
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    internal class Resources {
        
        private static global::System.Resources.ResourceManager resourceMan;
        
        private static global::System.Globalization.CultureInfo resourceCulture;
        
        [global::System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal Resources() {
        }
        
        /// <summary>
        ///   Returns the cached ResourceManager instance used by this class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static global::System.Resources.ResourceManager ResourceManager {
            get {
                if (object.ReferenceEquals(resourceMan, null)) {
                    global::System.Resources.ResourceManager temp = new global::System.Resources.ResourceManager("Dora.Interception.Properties.Resources", typeof(Resources).Assembly);
                    resourceMan = temp;
                }
                return resourceMan;
            }
        }
        
        /// <summary>
        ///   Overrides the current thread's CurrentUICulture property for all
        ///   resource lookups using this strongly typed resource class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static global::System.Globalization.CultureInfo Culture {
            get {
                return resourceCulture;
            }
            set {
                resourceCulture = value;
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Unable to activate type &apos;{0}&apos;. The following constructors are ambigious:.
        /// </summary>
        internal static string AmbigiousConstructorException {
            get {
                return ResourceManager.GetString("AmbigiousConstructorException", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Unable to activate type &apos;{0}&apos;. The following constructors are ambiguous:.
        /// </summary>
        internal static string AmbiguousConstructorException {
            get {
                return ResourceManager.GetString("AmbiguousConstructorException", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to &apos;{0}&apos; type only implements IAsyncDisposable. Use DisposeAsync to dispose the container..
        /// </summary>
        internal static string AsyncDisposableServiceDispose {
            get {
                return ResourceManager.GetString("AsyncDisposableServiceDispose", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Unable to resolve service for type &apos;{0}&apos; while attempting to activate &apos;{1}&apos;..
        /// </summary>
        internal static string CannotResolveService {
            get {
                return ResourceManager.GetString("CannotResolveService", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to A circular dependency was detected for the service of type &apos;{0}&apos;..
        /// </summary>
        internal static string CircularDependencyException {
            get {
                return ResourceManager.GetString("CircularDependencyException", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Constant value of type &apos;{0}&apos; can&apos;t be converted to service type &apos;{1}&apos;.
        /// </summary>
        internal static string ConstantCantBeConvertedToServiceType {
            get {
                return ResourceManager.GetString("ConstantCantBeConvertedToServiceType", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Cannot resolve {1} service &apos;{0}&apos; from root provider..
        /// </summary>
        internal static string DirectScopedResolvedFromRootException {
            get {
                return ResourceManager.GetString("DirectScopedResolvedFromRootException", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Duplicate InterceptorProviderResolver with the name &quot;{0}&quot; is registered..
        /// </summary>
        internal static string DuplicateInterceptorProviderResolverIsAdded {
            get {
                return ResourceManager.GetString("DuplicateInterceptorProviderResolverIsAdded", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Implementation type &apos;{0}&apos; can&apos;t be converted to service type &apos;{1}&apos;.
        /// </summary>
        internal static string ImplementationTypeCantBeConvertedToServiceType {
            get {
                return ResourceManager.GetString("ImplementationTypeCantBeConvertedToServiceType", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to The InterceptorProviderResolver with name &quot;{0}&quot; is not registered..
        /// </summary>
        internal static string InterceptorProviderResolverNotRegistered {
            get {
                return ResourceManager.GetString("InterceptorProviderResolverNotRegistered", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to A suitable constructor for type &apos;{0}&apos; could not be located. Ensure the type is concrete and services are registered for all parameters of a public constructor..
        /// </summary>
        internal static string NoConstructorMatch {
            get {
                return ResourceManager.GetString("NoConstructorMatch", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to The specified is not a method call expression..
        /// </summary>
        internal static string NotMethodCallExpression {
            get {
                return ResourceManager.GetString("NotMethodCallExpression", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to The specified is not a property access expression..
        /// </summary>
        internal static string NotPropertyAccessExpression {
            get {
                return ResourceManager.GetString("NotPropertyAccessExpression", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Open generic service type &apos;{0}&apos; requires registering an open generic implementation type..
        /// </summary>
        internal static string OpenGenericServiceRequiresOpenGenericImplementation {
            get {
                return ResourceManager.GetString("OpenGenericServiceRequiresOpenGenericImplementation", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to The property &quot;{0}&quot; of &quot;{1}&quot; does not have a Get method..
        /// </summary>
        internal static string PropertyHasNoGetMethod {
            get {
                return ResourceManager.GetString("PropertyHasNoGetMethod", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to The property &quot;{0}&quot; of &quot;{1}&quot; does not have a Set method..
        /// </summary>
        internal static string PropertyHasNoSetMethod {
            get {
                return ResourceManager.GetString("PropertyHasNoSetMethod", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Cannot consume {2} service &apos;{0}&apos; from {3} &apos;{1}&apos;..
        /// </summary>
        internal static string ScopedInSingletonException {
            get {
                return ResourceManager.GetString("ScopedInSingletonException", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Cannot resolve &apos;{0}&apos; from root provider because it requires {2} service &apos;{1}&apos;..
        /// </summary>
        internal static string ScopedResolvedFromRootException {
            get {
                return ResourceManager.GetString("ScopedResolvedFromRootException", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Cannot instantiate implementation type &apos;{0}&apos; for service type &apos;{1}&apos;..
        /// </summary>
        internal static string TypeCannotBeActivated {
            get {
                return ResourceManager.GetString("TypeCannotBeActivated", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to No constructor for type &apos;{0}&apos; can be instantiated using services from the service container and default values..
        /// </summary>
        internal static string UnableToActivateTypeException {
            get {
                return ResourceManager.GetString("UnableToActivateTypeException", resourceCulture);
            }
        }
    }
}
