using System;

namespace API.Application.ViewModels
{
    public class CustomerViewModel
    {
        public Guid Id { get; set; }

        public string FirstName { get; private set; }

        public string LastName { get; private set; }

        public DateTimeOffset DateOfBirth { get; private set; }
    }
}
