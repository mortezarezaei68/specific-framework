using Anshan.Framework.Application.Command;
using Framework.Domain.UnitOfWork;

namespace Framework.Infra.ManualCommandHandlers
{
    public class TransactionalCommandHandlerDecorator<T> : ICommandHandler<T>
    {
        private readonly ICommandHandler<T> _commandHandler;
        private readonly IUnitOfWork _unitOfWork;

        public TransactionalCommandHandlerDecorator(ICommandHandler<T> commandHandler, IUnitOfWork unitOfWork)
        {
            _commandHandler = commandHandler;
            _unitOfWork = unitOfWork;
        }

        public async Task Handle(T command)
        {
            var transaction = await _unitOfWork.BeginTransactionAsync();

            try
            {
                await _commandHandler.Handle(command);
                await _unitOfWork.CommitAsync(transaction);
            }
            catch (System.Exception exception)
            {
                _unitOfWork.RollbackTransaction();
                throw new System.Exception(exception.Message, exception);
            }
        }
    }

    public class CommandHandlerDecorator<T> : ICommandHandler<T>
    {
        private readonly ICommandHandler<T> _commandHandler;

        public CommandHandlerDecorator(ICommandHandler<T> commandHandler)
        {
            _commandHandler = commandHandler;
        }

        public async Task Handle(T command)
        {
            try
            {
                await _commandHandler.Handle(command);
            }
            catch (System.Exception exception)
            {
                throw new System.Exception(exception.Message, exception);
            }
        }
    }
}