using Domain.Aggregates.CustomerAggregate;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace API.Application.Commands
{
    public class CreateCustomerCommandHandler : IRequestHandler<CreateCustomerCommand, Customer>
    {
        private readonly ICustomerRepository _customerRepository;

        public CreateCustomerCommandHandler(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }

        /// <summary>
        /// Add customer data to the customer table 
        /// </summary>
        /// <param name="request"> first name, Last Name, Dat of Birth</param>
        /// <param name="cancellationToken"></param>
        /// <returns>inserted customer data</returns>
        public async Task<Customer> Handle(CreateCustomerCommand request, CancellationToken cancellationToken)
        {
            var customer = _customerRepository.Add(new Customer(request.FirstName, request.LastName,request.DateOfBirth));

            await _customerRepository.UnitOfWork.SaveEntitiesAsync();

            return customer;
        }
    }
}
