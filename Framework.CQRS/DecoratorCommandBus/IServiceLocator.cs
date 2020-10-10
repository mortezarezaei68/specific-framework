using System.Collections.Generic;

namespace Framework.CQRS.DecoratorCommandBus
{
    public interface IServiceLocator
    {
        T GetInstance<T>();
        List<object> GetInstances<T>();

        void Release(object obj);
    }
}