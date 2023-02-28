namespace Framework.Infra.ManualCommandHandlers.EventBus
{
    public interface IServiceLocator
    {
        T GetInstance<T>();
        List<object> GetInstances<T>();

        void Release(object obj);
    }
}