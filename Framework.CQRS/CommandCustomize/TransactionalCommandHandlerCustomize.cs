using System;
using System.Threading;
using System.Threading.Tasks;
using Framework.EF.ContextFrameWork;
using MediatR;

namespace Framework.CQRS.CommandCustomize
{
    public class TransactionalCommandHandlerCustomize<TCommand,TResponse>:ICommandHandlerCustomize<TCommand,TResponse> where TCommand : IRequest<TResponse> where TResponse : ResponseCommand
    {
        private readonly IUnitOfWork _unitOfWork;
        protected TResponse Result { get; set; }
        public TransactionalCommandHandlerCustomize(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<TResponse> Handle(TCommand request, CancellationToken cancellationToken, RequestHandlerDelegate<TResponse> next)
        {
            var response = default(TResponse);

            try
            {
                var transaction = await _unitOfWork.BeginTransactionAsync();

                    response = await next(); 
                    await _unitOfWork.CommitAsync(transaction);
                    return response;
            }
            catch (Exception ex)
            {

                throw;
            }
        }
    }
}