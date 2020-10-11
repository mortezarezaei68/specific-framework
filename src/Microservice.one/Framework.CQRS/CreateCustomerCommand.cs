using System;
using MediatR;

namespace Framework.CQRS
{
    public class CreateCustomerCommand : IRequest<CreateCustomerResponseCommand>
    {
        public string Name { get; set; }

        public string Email { get; set; }

        public DateTime BirthDate => DateTime.Now;
    }
}