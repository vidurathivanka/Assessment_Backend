using Domain.Aggregates.CustomerAggregate;
using Domain.Aggregates.OrderAggregate;
using MediatR;
using System;

namespace API.Application.Commands
{
    public class CreateCustomerCommand : IRequest<Customer>
    {
        public string FirstName { get; private set; }

        public string LastName { get; private set; }
        public DateTime DateOfBirth { get; private set; }

        public CreateCustomerCommand(string firstname, string lastname, DateTime dateofbirth)
        {
            FirstName = firstname;
            LastName = lastname;
            DateOfBirth = dateofbirth;
        }
    
    }
}
