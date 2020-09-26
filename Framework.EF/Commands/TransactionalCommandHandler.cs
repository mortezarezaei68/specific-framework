using System;
using System.Threading.Tasks;
using Framework.EF.ContextFrameWork;
using Microsoft.Extensions.Logging;

namespace Framework.EF.Commands
{
    public class TransactionalCommandHandler<TCommand>:ICommandHandler<TCommand>
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