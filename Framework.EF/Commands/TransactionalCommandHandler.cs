using System;
using System.Threading.Tasks;
using Framework.EF.ContextFrameWork;
using Microsoft.Extensions.Logging;

namespace Framework.EF.Commands
{
    public abstract class TransactionalCommandHandler<TCommand>:ICommandHandler<TCommand>
    {
        private readonly ILogger<TransactionalCommandHandler<TCommand>> _logger;
        private readonly ICommandHandler<TCommand> _commandHandler;
        private readonly IUnitOfWork _unitOfWork;

        protected TransactionalCommandHandler(ICommandHandler<TCommand> commandHandler, IUnitOfWork unitOfWork, ILogger<TransactionalCommandHandler<TCommand>> logger)
        {
            _commandHandler = commandHandler;
            _unitOfWork = unitOfWork;
            _logger = logger;
        }

        public async Task Handle(TCommand command)
        {
            var transaction=await _unitOfWork.BeginTransactionAsync();
            try
            {
                await _commandHandler.Handle(command);
                await _unitOfWork.CommitAsync(transaction);
            }
            catch (Exception e)
            {
                _unitOfWork.RollbackTransaction();
                throw new Exception(e.Message, e);
            }
        }
    }
}