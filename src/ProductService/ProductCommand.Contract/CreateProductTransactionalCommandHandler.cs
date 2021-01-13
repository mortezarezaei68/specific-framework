using System;
using System.Threading;
using System.Threading.Tasks;
using Framework.Commands.CommandHandlers;
using MediatR;
using ProductModel.Command.ProductCommand;

namespace ProductCommand.Contract
{
    public class CreateProductTransactionalCommandHandler:ITransactionalCommandHandlerMediatR<CreateProductCommandRequest,CreateProductCommandResponse>
    {
        public Task<CreateProductCommandResponse> Handle(CreateProductCommandRequest request, CancellationToken cancellationToken, RequestHandlerDelegate<CreateProductCommandResponse> next)
        {
            throw new NotImplementedException();
        }
    }
}