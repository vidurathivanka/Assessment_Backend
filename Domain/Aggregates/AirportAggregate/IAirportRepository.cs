using System;
using System.Threading.Tasks;
using Domain.SeedWork;

namespace Domain.Aggregates.AirportAggregate
{
    public interface IAirportRepository : IRepository<Airport>
    {
        Airport Add(Airport airport);

        void Update(Airport airport);

        /// <summary>
        /// Get Airport by  Id
        /// </summary>
        /// <param name="airportId">airport id</param>
        /// <returns>Airport details</returns>
        Task<Airport> GetAsync(Guid airportId);

        /// <summary>
        /// Get Airport by Code
        /// </summary>
        /// <param name="code">code string</param>
        /// <returns>Airport details</returns>
        Task<Airport> GetAirportByCode(string code);
    }
}