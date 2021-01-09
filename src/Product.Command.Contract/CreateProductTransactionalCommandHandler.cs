using System;
using System.Threading;
using System.Threading.Tasks;
using Framework.EventBase.CommandHandlers;
using MediatR;
using Product.Service.CQRS.ProductCommand;


namespace Product.Command.Contract
{
    public class CreateProductTransactionalCommandHandler:ITransactionalCommandHandlerMediatR<CreateProductCommandRequest,CreateProductCommandResponse>
    {
        public Task<CreateProductCommandResponse> Handle(CreateProductCommandRequest request, CancellationToken cancellationToken, RequestHandlerDelegate<CreateProductCommandResponse> next)
        {
            throw new NotImplementedException();
        }
    }
}