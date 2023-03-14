using Domain.SeedWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Aggregates.OrderAggregate
{
    public class Order : Entity, IAggregateRoot
    {
        public Guid CustomerId { get; private set; }

        public Guid FlightId { get; private set; }
        public Guid FlightRateId { get; private set; }
        public decimal Amount { get; private set; }
        public Int16 Status { get; private set; }
        public int Quantity { get; private set; }
        public Order()
        {
        }
        public void UpdateStatus(Int16 status)
        {
            Status = status;
        }

        public void UpdateAmount(decimal amount)
        {
            Amount = amount;
        }
        public Order(Guid custid, Guid flightid, Guid flightRateid, Int16 status, int quantity,decimal amount) : this()
        {
            CustomerId = custid;
            FlightId = flightid;
            FlightRateId = flightRateid;
            Amount = amount;
            Status = status;
            Quantity = quantity;
        }
    }
}
