using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Exceptions;
using Domain.SeedWork;

namespace Domain.Aggregates.CustomerAggregate
{
    public class Customer : Entity, IAggregateRoot
    { 
        public string FirstName { get; private set; }

        public string LastName { get; private set; }
        public DateTime DateOfBirth { get; private set; }

        public Customer()
        {
        }

        public Customer(string fname, string lname, DateTime dob) : this()
        {
            if (fname.Length < 2)
            {
                throw new AirportDomainException("The first name must be atleast one characters.");
            }

            FirstName = fname;
            LastName = lname;
            DateOfBirth = dob;
        }
    }
}
