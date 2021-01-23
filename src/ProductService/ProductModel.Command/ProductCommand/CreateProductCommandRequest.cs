using MediatR;

namespace ProductModel.Command.ProductCommand
{
    public class CreateProductCommandRequest : IRequest<CreateProductCommandResponse>
    {
        public string Name { get; set; }
        public string Description { get; set; }
    }
}