
using Framework.CQRS.MediatRCommands;

namespace Product.Service.CQRS.AddProductCommand
{
    public class CreateProductResponseCommand : ResponseCommand
    {
        public string Id { get; set; }
    }
}