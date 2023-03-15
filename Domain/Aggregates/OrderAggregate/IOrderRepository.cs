using Domain.SeedWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Aggregates.OrderAggregate
{
    public interface IOrderRepository : IRepository<Order>
    {
        Order Add(Order order);

        void Update(Order order);

        Task<Order> GetAsync(Guid orderId);

        Task<List<Order>> GetOrders();

        /// <summary>
        /// Order details filted by flight id
        /// </summary>
        /// <param name="flighId">fligh Id</param>
        /// <returns>Ordre List</returns>
        Task<List<Order>> GetOrderbyFlight(Guid flighId);

        /// <summary>
        /// Get Order details by filter the status as DRAFT
        /// </summary>
        /// <param name="flighrateId">flighrate Id</param>
        /// <returns>order details</returns>
        Task<List<Order>> GetDraftOrderbyFlightRate(Guid flighrateId);

    }
}
