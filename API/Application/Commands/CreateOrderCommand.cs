using Domain.Aggregates.OrderAggregate;
using MediatR;
using System;

namespace API.Application.Commands
{
    public class CreateOrderCommand : IRequest<Order>
    {
        public Guid CustomerId { get; private set; }
        public Guid FlightId { get; private set; }
        public Guid FlightRateId { get; private set; }
        public decimal Amount { get; private set; }
        public Int16 Status { get; private set; }
        public int Quantity { get; private set; }

        public CreateOrderCommand(Guid customerid, Guid flightid, Guid flightrateid, decimal amount,int quantity)
        {
            FlightId = flightid;
            FlightRateId = flightrateid;
            CustomerId = customerid;
            Amount = amount;
            Quantity = quantity;
        }
    }
}
