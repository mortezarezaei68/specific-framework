using System;
using Framework.EF.Framework.Domain;

namespace Framework.EF
{
    public class Customer : AggregateRoot<Guid>
    {
        public Customer(string name, string email, DateTime birthDate)
        {
            Name = name;
            Email = email;
            BirthDate = birthDate;
        }


        // Empty constructor for EF
        protected Customer()
        {
        }

        public string Name { get; }

        public string Email { get; }

        public DateTime BirthDate { get; }
    }
}