using System;
using System.Collections.Generic;
using Microsoft.Extensions.DependencyInjection;

namespace Framework.Buses
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

    public static class ServiceProviderExtensions
    {
        /// <summary>
        /// Get all registered <see cref="ServiceDescriptor"/>
        /// </summary>
        /// <param name="provider"></param>
        /// <param name="serviceType"></param>
        /// <returns></returns>
        public static IEnumerable<object> GetAllServiceDescriptors(this IServiceProvider provider,Type serviceType)
        {
            if (provider is not ServiceProvider serviceProvider)
                throw new NotSupportedException($"Type '{provider.GetType()}' is not supported!");
            
            var engine = serviceProvider.GetServices(serviceType);
    
            return engine;

        }
    }
}