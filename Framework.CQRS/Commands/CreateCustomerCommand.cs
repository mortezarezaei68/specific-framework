using System;
using Framework.CQRS.MediatRCommands;
using MediatR;

namespace Framework.EF.Commands
{
    public class CreateCustomerCommand:IRequest<CreateCustomerResponseCommand>
    {
        public string Name { get;  set; }

        public string Email { get;  set; }

        public DateTime BirthDate =>DateTime.Now;
    }

    public class CreateCustomerResponseCommand:ResponseCommand
    {
        public string Id { get; set; }
    }
}