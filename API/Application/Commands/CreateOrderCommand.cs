using API.Application.ViewModels;
using MediatR;
using System;

namespace API.Application.Commands
{
    public class CreateOrderCommand : IRequest<OrderViewModel>
    {
        public Guid CustomerId { get; private set; }
        public Guid FlightId { get; private set; }
        public Guid FlightRateId { get; private set; } 
        public int Quantity { get; private set; }

        public CreateOrderCommand(Guid customerid, Guid flightid, Guid flightrateid, int quantity)
        {
            FlightId = flightid;
            FlightRateId = flightrateid;
            CustomerId = customerid;
            Quantity = quantity;
        }
    }
}
