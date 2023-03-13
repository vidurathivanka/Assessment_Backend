using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using API.ApiResponses;
using API.Application.Commands;
using API.Application.Queries;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace API.Controllers;

[ApiController]
[Route("[controller]")]
public class FlightsController : ControllerBase
{
    private readonly ILogger<FlightsController> _logger;
    private readonly IMediator _mediator;
    private readonly IMapper _mapper;
    public FlightsController(
           ILogger<FlightsController> logger,
           IMediator mediator,
           IMapper mapper)
    {
        _logger = logger;
        _mediator = mediator;
        _mapper = mapper;
    }

    [HttpGet("{value}")]
    public Task<List<FlightResponse>> GetAvailableFlights(string value)
    {
       var flight =   _mediator.Send( new GetAvailableFlightbydestinationQuery(value));
        // return Ok(_mapper.Map<FlightResponse>(flight));
        return flight;        

    }

    [HttpPost]
    public async Task<IActionResult> UpdateFlightRate([FromBody] UpdateFlightRateCommand command)
    {
        var flightrate = await _mediator.Send(command);
        return Ok(flightrate);
        //return Ok(_mapper.Map<OrderViewModel>(Order));
    }
}
