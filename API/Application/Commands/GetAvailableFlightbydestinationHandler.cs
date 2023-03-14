using API.ApiResponses;
using API.Application.Queries;
using AutoMapper;
using Domain.Aggregates.AirportAggregate;
using Domain.Aggregates.FlightAggregate;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace API.Application.Commands
{
    public class GetAvailableFlightbydestinationHandler : IRequestHandler<GetAvailableFlightbydestinationQuery, List<FlightResponse>>
    {
        private readonly IFlightRepository _flightRepository; 
        private readonly IAirportRepository _airportRepository;
        private readonly IFlightRateRepository _flightRateRepository; 
        public GetAvailableFlightbydestinationHandler(IFlightRepository flightRepository, IAirportRepository airportRepository, IFlightRateRepository flightRateRepository)
        {
            _airportRepository = airportRepository;
            _flightRepository = flightRepository;
            _flightRateRepository = flightRateRepository;
        }

        public async Task<List<FlightResponse>> Handle(GetAvailableFlightbydestinationQuery request, CancellationToken cancellationToken)
        {

            List<FlightResponse> FlightList = new List<FlightResponse>();
            //get airtport detail by destination name
            var destinationairport = await _airportRepository.GetAirportByCode(request.code);
            if (destinationairport != null)
            {
                // get all the flights details
                var flights = await _flightRepository.GetFlights();
                // get flight list by destination id
                var searchedairport = flights.FindAll(x => x.DestinationAirportId == destinationairport.Id);
                if (searchedairport.Count > 0)
                {
                    FlightResponse flight;
                    foreach (Flight f in searchedairport)
                    {
                        //get depature aiport 
                        var OriginAirport = await _airportRepository.GetAsync(f.OriginAirportId);
                        //get minimum price from flight rates
                        decimal minrate = await _flightRateRepository.GetMinRateByFlight(f.Id);
                        if (minrate != -1)
                        {
                            flight = new FlightResponse(OriginAirport.Code, destinationairport.Code, f.Departure, f.Arrival, minrate);
                            FlightList.Add(flight);
                        }

                    }
                }
                else
                {
                    FlightList.Add(new FlightResponse("Error", "",System.DateTimeOffset.MaxValue, System.DateTimeOffset.MaxValue,0));
                }

            }
            return  FlightList;
        }
        
    }
    
}
