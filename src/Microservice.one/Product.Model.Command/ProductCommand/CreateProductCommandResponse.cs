using Framework.EventBase.CommandHandlers;

namespace Product.Service.CQRS.ProductCommand
{
    public class CreateProductCommandResponse : ResponseCommand<CreateProductViewModel>
    {
        public CreateProductCommandResponse(bool isSuccess, string message = null, CreateProductViewModel data = null) : base(isSuccess, message, data)
        {
        }
    }

    public class CreateProductViewModel
    {
        public int Id { get; set; }
    }
}