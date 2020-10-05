using Framework.CQRS.MediatRCommands;
using MediatR;

namespace Framework.CQRS.Commands
{
    public class CreateTestAggregateCommand:IRequest<CreateTestAggregateResponseCommand>
    {
        public string Name { get; set; }
    }

    public class CreateTestAggregateResponseCommand:ResponseCommand
    {
        public int Id { get; set; }
    }
}