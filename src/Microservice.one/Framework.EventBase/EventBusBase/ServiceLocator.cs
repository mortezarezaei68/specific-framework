using System;
using System.Collections.Generic;

namespace EventBase.EventBusBase
{
    public class ServiceLocator : IServiceLocator
    {
        private readonly IServiceProvider _serviceProvider;

        public ServiceLocator(IServiceProvider services)
        {
            _serviceProvider = services;
        }

        public T GetInstance<T>()
        {
            var service = (T) _serviceProvider.GetService(typeof(T));
            return service;
        }

        public List<object> GetInstances<T>()
        {
            return null;
        }

        public void Release(object obj)
        {
        }
    }

    // public static class IServiceProviderExtensions
    // {
    //     /// <summary>
    //     /// Get all registered <see cref="ServiceDescriptor"/>
    //     /// </summary>
    //     /// <param name="provider"></param>
    //     /// <returns></returns>
    //     public static IEnumerable<object> GetAllServiceDescriptors(this IServiceProvider provider,Type serviceType)
    //     {
    //         if (provider is ServiceProvider serviceProvider)
    //         {
    //             var engine = serviceProvider.GetServices(serviceType);
    //
    //             return engine;
    //         }
    //
    //         throw new NotSupportedException($"Type '{provider.GetType()}' is not supported!");
    //     }
    // }
}