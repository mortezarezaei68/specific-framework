using System;
using System.Threading;
using System.Threading.Tasks;
using Common.Exceptions;
using Framework.Commands.CommandHandlers;
using Framework.Domain;
using Framework.Domain.UnitOfWork;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Framework.EventBase.CommandHandlers
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
                var transaction = await _unitOfWork.BeginTransactionAsync();

                response = await next();

                await _unitOfWork.CommitAsync(transaction);
                return response;
            }
            catch (AppException ex)
            {
                throw;
            }
        }
    }
}