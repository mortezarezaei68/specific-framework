namespace Framework.Domain.UnitOfWork
{
    public interface IRepository
    {
        IUnitOfWork UnitOfWork { get; }
    }
}