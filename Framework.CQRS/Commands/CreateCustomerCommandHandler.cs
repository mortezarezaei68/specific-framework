using System.Threading.Tasks;
using Framework.EF.ContextFrameWork;

namespace Framework.EF.Commands
{
    public class CreateCustomerCommandHandler:ICommandHandler<CreateCustomerCommand>
    {
        private readonly ICustomerRepository _repository;

        public CreateCustomerCommandHandler(ICustomerRepository repository)
        {
            _repository = repository;
        }

        public Task Handle(CreateCustomerCommand command)
        {
            _repository.Add(new Customer(command.Name,command.Email,command.BirthDate));
            return Task.CompletedTask;
        }
    }
}