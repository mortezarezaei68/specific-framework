using Microsoft.EntityFrameworkCore.Storage;

namespace Framework.Infra.EntityFramework.UnitOfWork
{
    public interface IUnitOfWork : IDisposable
    {
        bool HasActiveTransaction { get; }
        Task<IDbContextTransaction> BeginTransactionAsync();
        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);

        Task CommitAsync(IDbContextTransaction transaction);

        void RollbackTransaction();
    }
}