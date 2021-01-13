using System.Collections.Generic;

namespace Bus.EventbusManager
{
    public interface IServiceLocator
    {
        T GetInstance<T>();
        List<object> GetInstances<T>();

        void Release(object obj);
    }
}