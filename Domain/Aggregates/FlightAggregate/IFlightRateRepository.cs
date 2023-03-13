using Domain.SeedWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Aggregates.FlightAggregate
{
    public interface IFlightRateRepository : IRepository<FlightRate>
    {
        FlightRate Add(FlightRate flight);

        void Update(FlightRate flight);

        Task<FlightRate> GetAsync(Guid flightrateId);

        List<FlightRate> GetFlightRates();

        Task<decimal> GetMinRateByFlight(Guid flightId);
    }
}
