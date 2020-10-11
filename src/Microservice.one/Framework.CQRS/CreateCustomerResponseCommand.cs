using Framework.CQRS.MediatRCommands;

namespace Framework.CQRS
{
    public class CreateCustomerResponseCommand : ResponseCommand
    {
        public string Id { get; set; }
    }
}