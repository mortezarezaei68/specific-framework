using Framework.Domain.UnitOfWork;
using Framework.Exception.Exceptions;
using Framework.Exception.Exceptions.Enum;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Framework.Infra.MediatR
{
    public class TransactionalCommandHandlerMediatR<TCommand, TResponse> : ITransactionalCommandHandlerMediatR<
            TCommand, TResponse> where TCommand : IRequest<TResponse> where TResponse : class
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
            try
            {
                if (_unitOfWork.HasActiveTransaction) return await next();
                await using var transaction = await _unitOfWork.BeginTransactionAsync();
                var response = await next();
                await _unitOfWork.CommitAsync(transaction);
                return response;
            }
            catch (AppException ex)
            {
                _unitOfWork.RollbackTransaction();
                throw new AppException(ex.Message,ResultCode.BadRequest);
            }
        }
    }
}