using System;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Storage;

namespace Framework.EF.ContextFrameWork
{
    public interface IUnitOfWork : IDisposable
    {
        Task<IDbContextTransaction> BeginTransactionAsync();

        Task CommitAsync(IDbContextTransaction transaction);

        void RollbackTransaction();
    }
}