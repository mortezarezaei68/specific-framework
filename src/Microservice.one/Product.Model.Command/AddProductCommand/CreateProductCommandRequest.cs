using MediatR;

namespace Product.Service.CQRS.AddProductCommand
{
    public class CreateProductCommandRequest : IRequest<CreateProductResponseCommand>
    {
        public string Name { get; set; }
    }
}