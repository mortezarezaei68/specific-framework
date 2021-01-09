using MediatR;

namespace Product.Service.CQRS.ProductCommand
{
    public class CreateProductCommandRequest : IRequest<CreateProductCommandResponse>
    {
        public string Name { get; set; }
    }
}