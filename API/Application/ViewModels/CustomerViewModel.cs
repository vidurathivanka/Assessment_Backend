using System;

namespace API.Application.ViewModels
{
    public class CustomerViewModel
    {
        public Guid Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get;  set; }

        public DateTimeOffset DateOfBirth { get;  set; }
    }
}
