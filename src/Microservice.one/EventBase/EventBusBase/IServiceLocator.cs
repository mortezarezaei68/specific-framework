using System.Collections.Generic;

namespace EventBase.EventBusBase
{
    public interface IServiceLocator
    {
        T GetInstance<T>();
        List<object> GetInstances<T>();

        void Release(object obj);
    }
}