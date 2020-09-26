using System.Threading.Tasks;

namespace Framework.EF.Commands
{
    public class CreateCustomerCommandHandler:ICommandHandler<CreateCustomerCommand>
    {
        public Task Handle(CreateCustomerCommand command)
        {
            return Task.CompletedTask;
        }
    }
}