using Framework.Domain;

namespace Microservice.Domain
{
    public interface IRepository
    {
        IUnitOfWork UnitOfWork { get; }
    }
}