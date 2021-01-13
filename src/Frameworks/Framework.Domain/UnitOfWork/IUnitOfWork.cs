using System;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Storage;

namespace Framework.Domain.UnitOfWork
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