namespace Framework.EF.DomainEvents
{
    public interface IServiceLocator
    {
        T GetInstance<T>();

        void Release(object obj);
    }
}