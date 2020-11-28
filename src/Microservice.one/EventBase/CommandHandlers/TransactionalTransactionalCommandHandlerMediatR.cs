using System;
using System.Threading;
using System.Threading.Tasks;
using Framework.CQRS.MediatRCommands;
using Framework.Domain;
using MediatR;
using Microsoft.Extensions.Logging;

namespace EventBase.CommandHandlers
{
    public class
        TransactionalTransactionalCommandHandlerMediatR<TCommand, TResponse> : ITransactionalCommandHandlerMediatR<
            TCommand, TResponse> where TCommand : IRequest<TResponse> where TResponse : ResponseCommand
    {
        private readonly ILogger<TransactionalTransactionalCommandHandlerMediatR<TCommand, TResponse>> _logger;
        private readonly IUnitOfWork _unitOfWork;

        public TransactionalTransactionalCommandHandlerMediatR(IUnitOfWork unitOfWork,
            ILogger<TransactionalTransactionalCommandHandlerMediatR<TCommand, TResponse>> logger)
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
                var transaction = await _unitOfWork.BeginTransactionAsync();

                response = await next();

                await _unitOfWork.CommitAsync(transaction);
                return response;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}