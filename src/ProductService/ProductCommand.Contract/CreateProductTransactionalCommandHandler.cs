using System;
using System.Threading;
using System.Threading.Tasks;
using Common;
using Framework.Commands.CommandHandlers;
using MediatR;
using ProductModel.Command.ProductCommand;
using ProductService.Domain;

namespace ProductCommand.Contract
{
    public class CreateProductTransactionalCommandHandler:ITransactionalCommandHandlerMediatR<CreateProductCommandRequest,CreateProductCommandResponse>
    {
        private readonly IProductRepository _productRepository;

        public CreateProductTransactionalCommandHandler(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public Task<CreateProductCommandResponse> Handle(CreateProductCommandRequest request, CancellationToken cancellationToken, RequestHandlerDelegate<CreateProductCommandResponse> next)
        {
            var data=_productRepository.Add(Product.Add(request.Name, request.Description));
            return Task.FromResult(new CreateProductCommandResponse(true,ResultCode.Success,new CreateProductViewModel{Id = data.Id}));
        }
    }
}