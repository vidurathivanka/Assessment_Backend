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

        /// <summary>
        /// Group by Flight ID and get the minimum amount 
        /// </summary>
        /// <param name="flightId"></param>
        /// <returns>return flight rates record with minimum amount</returns>
        Task<decimal> GetMinRateByFlight(Guid flightId);
    }
}
