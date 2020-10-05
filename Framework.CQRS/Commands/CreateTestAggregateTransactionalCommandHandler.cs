using System.Threading;
using System.Threading.Tasks;
using Framework.CQRS.MediatRCommands;
using Framework.EF;
using MediatR;

namespace Framework.CQRS.Commands
{
    public class CreateTestAggregateTransactionalCommandHandler:ITransactionalCommandHandlerMediatR<CreateTestAggregateCommand,CreateTestAggregateResponseCommand>
    {
        private readonly ITestAggregateRepository _repository;

        public CreateTestAggregateTransactionalCommandHandler(ITestAggregateRepository repository)
        {
            _repository = repository;
        }

        public Task<CreateTestAggregateResponseCommand> Handle(CreateTestAggregateCommand request, CancellationToken cancellationToken, RequestHandlerDelegate<CreateTestAggregateResponseCommand> next)
        {
            _repository.Add(new TestAggregate(request.Name));
            return null;
        }
    }
}