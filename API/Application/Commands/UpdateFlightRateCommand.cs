using Domain.Aggregates.FlightAggregate;
using Domain.Common;
using MediatR;
using System;

namespace API.Application.Commands
{
    public class UpdateFlightRateCommand : IRequest<FlightRate>
    {
        public Guid Id { get; private set; }
        public Price Price { get; private set; }

        public UpdateFlightRateCommand(Guid id, Price price)
        {
            Id = id;
            Price = new Price(price.Value, Currency.EUR); 

        }
    }
}
