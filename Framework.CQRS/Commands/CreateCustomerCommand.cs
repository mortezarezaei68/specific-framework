using System;

namespace Framework.EF.Commands
{
    public class CreateCustomerCommand
    {
        public string Name { get;  set; }

        public string Email { get;  set; }

        public DateTime BirthDate =>DateTime.Now;
    }
}