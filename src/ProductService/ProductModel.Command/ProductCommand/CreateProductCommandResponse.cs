using Common;
using Framework.Commands.CommandHandlers;

namespace ProductModel.Command.ProductCommand
{
    public class CreateProductCommandResponse : ResponseCommand<CreateProductViewModel>
    {
        public CreateProductCommandResponse(bool isSuccess, ResultCode resultCode, CreateProductViewModel data, string message = null) : base(isSuccess, resultCode, data, message)
        {
        }
    }

    public class CreateProductViewModel
    {
        public int Id { get; set; }
    }
}