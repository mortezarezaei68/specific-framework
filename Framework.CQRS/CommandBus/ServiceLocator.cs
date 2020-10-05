using System;

namespace Framework.CQRS.CommandBus
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

        public void Release(object obj)
        {
        }
    }
}