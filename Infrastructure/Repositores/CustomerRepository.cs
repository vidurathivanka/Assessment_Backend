using Domain.Aggregates.CustomerAggregate;
using Domain.SeedWork;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositores
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly FlightsContext _context;

        public IUnitOfWork UnitOfWork
        {
            get { return _context; }
        }
        public CustomerRepository(FlightsContext context)
        {
            _context = context;
        }

        public async Task<Customer> GetAsync(Guid customerid)
        {
            return await _context.Customer.FirstOrDefaultAsync(x => x.Id == customerid);
        }

        /// <summary>
        /// Get customer details which conains first name or last name of given string
        /// </summary>
        /// <param name="name"> name </param>
        /// <returns> customer detail list</returns>
        public async Task<List<Customer>> GetbyNameAsync(string name)
        {
            return await _context.Customer.Where(x => x.FirstName.ToLower().Contains(name.ToLower()) || x.LastName.ToLower().Contains(name.ToLower())).ToListAsync();
        }

        public Customer Add(Customer customer)
        {
            return _context.Customer.Add(customer).Entity; 
        }

        public void Update(Customer customer)
        { 
            _context.Customer.Update(customer); 
        }

    }
}
