using Framework.Domain.UnitOfWork;
using Framework.Exception.Exceptions;

namespace Framework.Infra.ManualCommandHandlers.CommandHandlers
{
    public abstract class TransactionalCommandHandler<TCommand> : ICommandHandler<TCommand>
    {
        private readonly ICommandHandler<TCommand> _commandHandler;
        private readonly IUnitOfWork _unitOfWork;

        protected TransactionalCommandHandler(ICommandHandler<TCommand> commandHandler, IUnitOfWork unitOfWork)
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
                throw e;
            }
        }
    }
}