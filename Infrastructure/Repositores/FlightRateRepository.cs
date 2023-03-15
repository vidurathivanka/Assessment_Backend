using Domain.Aggregates.FlightAggregate;
using Domain.SeedWork;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositores
{
    public class FlightRateRepository : IFlightRateRepository
    {
        private readonly FlightsContext _context;

        public IUnitOfWork UnitOfWork
        {
            get { return _context; }
        }

        public FlightRateRepository(FlightsContext context)
        {
            _context = context;
        }

        public FlightRate Add(FlightRate flightrate)
        {
            return _context.FlightRates.Add(flightrate).Entity;
        }

        public void Update(FlightRate flightrate)
        {
            _context.FlightRates.Update(flightrate);
        }
       public List<FlightRate> GetFlightRates()
        {
            return _context.FlightRates.ToList();
        }

        public async Task<FlightRate> GetAsync(Guid flightrateId)
        {
            return await _context.FlightRates.FirstOrDefaultAsync(x=> x.Id == flightrateId); 
        }


        /// <summary>
        /// Group by Flight ID and get the minimum amount 
        /// </summary>
        /// <param name="flightId"></param>
        /// <returns>return flight rates record with minimum amount</returns>
        public async Task<decimal> GetMinRateByFlight(Guid flightId)
        {
            return await _context.FlightRates.Where(o => o.FlightId == flightId).MinAsync(x => x.Price.Value);
            
        }

    }
}
