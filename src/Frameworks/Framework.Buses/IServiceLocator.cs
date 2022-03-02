using System.Collections.Generic;

namespace Framework.Buses
{
    public interface IServiceLocator
    {
        T GetInstance<T>();
        List<object> GetInstances<T>();

        void Release(object obj);
    }
}