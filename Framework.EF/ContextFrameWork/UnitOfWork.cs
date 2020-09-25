using System;
using System.Data;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Framework.EF.DomainEvents;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;

namespace Framework.EF.ContextFrameWork
{
    public class UnitOfWork<TContext> : IUnitOfWork where TContext:DbContext
    {
        private readonly TContext _context;
        private readonly IEventDispatcher _dispatcher;
        private IDbContextTransaction _currentTransaction;
        public bool HasActiveTransaction => _currentTransaction != null;
        public IDbContextTransaction GetCurrentTransaction() => _currentTransaction;
        public UnitOfWork(TContext context, IEventDispatcher dispatcher)
        {
            _context = context;
            _dispatcher = dispatcher;
        }

        public async Task<IDbContextTransaction> BeginTransactionAsync()
        {
            if (_currentTransaction != null) return null;

            _currentTransaction = await _context.Database.BeginTransactionAsync(IsolationLevel.ReadCommitted);

            return _currentTransaction;
        }

        public async Task<IDbContextTransaction> SaveChangesAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            if (_currentTransaction != null) return null;

            _currentTransaction = await _context.Database.BeginTransactionAsync(IsolationLevel.ReadCommitted, cancellationToken: cancellationToken);

            return _currentTransaction;
        }

        public async Task CommitAsync(IDbContextTransaction transaction)
        {
            if (transaction == null) throw new ArgumentNullException(nameof(transaction));
            if (transaction != _currentTransaction) throw new InvalidOperationException($"Transaction {transaction.TransactionId} is not current");

            try
            {
                await SaveChangesAsync();
                transaction.Commit();
            }
            catch
            {
                RollbackTransaction();
                throw;
            }
            finally
            {
                if (_currentTransaction != null)
                {
                    _currentTransaction.Dispose();
                    _currentTransaction = null;
                }
            }
        }

        public void RollbackTransaction()
        {
            try
            {
                _currentTransaction?.Rollback();
            }
            finally
            {
                if (_currentTransaction != null)
                {
                    _currentTransaction.Dispose();
                    _currentTransaction = null;
                }
            }
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}