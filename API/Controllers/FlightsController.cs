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

    /// <summary>
    /// Search airport code and get the destination then search the avaialable flights for the destination
    /// </summary>
    /// <param name="code"></param>
    /// <returns>the flight details with minmum flight rate</returns>
    [HttpGet("{code}")]
    public async Task<IActionResult> GetAvailableFlights(string code)
    {
       var flight =  await _mediator.Send( new GetAvailableFlightbydestinationQuery(code));
        if (flight.Count == 0)
        {
            return StatusCode(500, new { warrning = "there is no airport for the Searched airport code" });
        }else if (flight.Count == 1)
        {
           if( flight[0].DepartureAirportCode == "Error")
            {
                return StatusCode(500, new { warrning = "there is no available flights for the Searched airport code" });
            }
        }
        return Ok(flight); 
    }

    /// <summary>
    /// update the Flight Rate and update line amount of each customer order and notify to the customer
    /// </summary>
    /// <param name="command">Flight rate id and  amount</param>
    /// <returns></returns>
    [HttpPut]
    public async Task<IActionResult> UpdateFlightRate([FromBody] UpdateFlightRateCommand command)
    {
        var flightrate = await _mediator.Send(command);
        return Ok(flightrate);
        //return Ok(_mapper.Map<OrderViewModel>(Order));
    }
}
