using System.Threading;
using System.Threading.Tasks;
using Common.Exceptions;
using Framework.Domain.UnitOfWork;
using Framework.Exception.Exceptions.Enum;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Framework.Commands.CommandHandlers
{
    public class TransactionalCommandHandlerMediatR<TCommand, TResponse> : ITransactionalCommandHandlerMediatR<
            TCommand, TResponse> where TCommand : IRequest<TResponse> where TResponse : ResponseCommand
    {
        private readonly ILogger<TransactionalCommandHandlerMediatR<TCommand, TResponse>> _logger;
        private readonly IUnitOfWork _unitOfWork;

        public TransactionalCommandHandlerMediatR(IUnitOfWork unitOfWork,
            ILogger<TransactionalCommandHandlerMediatR<TCommand, TResponse>> logger)
        {
            _unitOfWork = unitOfWork;
            _logger = logger;
        }

        public async Task<TResponse> Handle(TCommand request, CancellationToken cancellationToken,
            RequestHandlerDelegate<TResponse> next)
        {
            var response = default(TResponse);

            try
            {
                if (_unitOfWork.HasActiveTransaction) return await next();
                using (var transaction = await _unitOfWork.BeginTransactionAsync())
                {
                  
                    response = await next();
                    await _unitOfWork.CommitAsync(transaction);
                    return response;
                }
            }
            catch (AppException ex)
            {
                _unitOfWork.RollbackTransaction();
                throw new AppException(ResultCode.BadRequest,ex.Message);
            }
        }
    }
}