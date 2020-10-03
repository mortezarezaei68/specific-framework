using System.Threading;
using System.Threading.Tasks;
using Framework.CQRS.MediatRCommands;
using Framework.EF.ContextFrameWork;
using Framework.EF.Framework.Domain;
using MediatR;

namespace Framework.EF.Commands
{
    public class CreateCustomerTransactionalCommandHandler:ITransactionalCommandHandlerMediatR<CreateCustomerCommand,CreateCustomerResponseCommand>
    {
        private readonly ICustomerRepository _repository;

        public CreateCustomerTransactionalCommandHandler(ICustomerRepository repository)
        {
            _repository = repository;
        }

        public Task Handle(CreateCustomerCommand command)
        {
            _repository.Add(new Customer(command.Name,command.Email,command.BirthDate));
            return Task.CompletedTask;
        }
        

        public Task<CreateCustomerResponseCommand> Handle(CreateCustomerCommand request, CancellationToken cancellationToken, RequestHandlerDelegate<CreateCustomerResponseCommand> next)
        {
            var result=_repository.Add(new Customer(request.Name,request.Email,request.BirthDate));
            return Task.FromResult(new CreateCustomerResponseCommand
            {
                Id = result.Id.ToString(),
                IsSuccess = true,
                Message = "test"
            });
        }
    }
}