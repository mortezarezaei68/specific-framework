using System;
using System.Threading.Tasks;
using Common.Exceptions;
using Framework.Domain.UnitOfWork;

namespace Framework.Commands.CommandHandlers
{
    public class TransactionalCommandHandler<TCommand> : ICommandHandler<TCommand>
    {
        private readonly ICommandHandler<TCommand> _commandHandler;
        private readonly IUnitOfWork _unitOfWork;

        public TransactionalCommandHandler(ICommandHandler<TCommand> commandHandler, IUnitOfWork unitOfWork)
        {
            _commandHandler = commandHandler;
            _unitOfWork = unitOfWork;
        }

        public async Task Handle(TCommand command)
        {
            var transaction = await _unitOfWork.BeginTransactionAsync();
            try
            {
                await _commandHandler.Handle(command);
                await _unitOfWork.CommitAsync(transaction);
            }
            catch (AppException e)
            {
                _unitOfWork.RollbackTransaction();
                throw;
            }
        }
    }
}