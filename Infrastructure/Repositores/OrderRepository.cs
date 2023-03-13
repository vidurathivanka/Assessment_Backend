using Domain.Aggregates.AirportAggregate;
using Domain.Aggregates.OrderAggregate;
using Domain.SeedWork;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositores
{
    public class OrderRepository : IOrderRepository
    {
        private readonly FlightsContext _context;

        public IUnitOfWork UnitOfWork
        {
            get { return _context; }
        }

        public OrderRepository(FlightsContext context)
        {
            _context = context;
        }

        public Order Add(Order order)
        {
            return _context.Order.Add(order).Entity; 
        }

        public void Update(Order order)
        {
            _context.Order.Update(order);
        }

        public async Task<Order> GetAsync(Guid orderId)
        {
            return await _context.Order.FirstOrDefaultAsync(x => x.Id == orderId);
        }

        public async Task<List<Order>> GetOrderbyFlight(Guid flighId)
        {
            return await _context.Order.Where(x => x.Id == flighId).ToListAsync();
        }

       public async Task<List<Order>> GetOrderbyFlightRate(Guid flighrateId)
        {
            return await _context.Order.Where(x => x.FlightRateId == flighrateId).ToListAsync();
        }

        Task<List<Order>> IOrderRepository.GetOrders()
        {
            throw new NotImplementedException();
        }

    }
}
