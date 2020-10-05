namespace Framework.CQRS.CommandBus
{
    public interface IServiceLocator
    {
        T GetInstance<T>();

        void Release(object obj);
    }
}