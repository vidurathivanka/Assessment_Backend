using API.ApiResponses;
using MediatR;
using System.Collections.Generic;
using System.Linq;

namespace API.Application.Queries
{
    public record GetAvailableFlightbydestinationQuery(string value) : IRequest<List<FlightResponse>>;
}
