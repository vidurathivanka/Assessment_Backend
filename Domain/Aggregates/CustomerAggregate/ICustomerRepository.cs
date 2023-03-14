using Domain.SeedWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Aggregates.CustomerAggregate
{
    public interface ICustomerRepository : IRepository<Customer>
    {
        Customer Add(Customer flight);

        void Update(Customer flight);

        Task<Customer> GetAsync(Guid customerid);
        Task<List<Customer>> GetbyNameAsync(string name);
    }
}
