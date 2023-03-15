using Domain.Aggregates.FlightAggregate;
using Domain.Common;
using MediatR;
using System;

namespace API.Application.Commands
{
    public class UpdateFlightRateCommand : IRequest<FlightRate>
    {
        public Guid Id { get; private set; }
        public decimal Price { get; private set; }

        public UpdateFlightRateCommand(Guid id, decimal price)
        {
            Id = id;
            Price = price; 

        }
    }
}
