using API.Application.Commands;
using AutoMapper;
using Domain.Aggregates.OrderAggregate;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;

namespace API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class OrderController : ControllerBase
    {
        private readonly ILogger<OrderController> _logger;
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;
        public OrderController(
               ILogger<OrderController> logger,
               IMediator mediator,
               IMapper mapper)
        {
            _logger = logger;
            _mediator = mediator;
            _mapper = mapper;
        }

        /// <summary>
        /// Order save as Draft
        /// </summary>
        /// <param name="command">customerid, flightid, flightrateid, quantity</param>
        /// <returns>ordre model</returns>
        [HttpPost]
        public async Task<IActionResult> Store([FromBody] CreateOrderCommand command)
        {
            var flightrate = await _mediator.Send(command); 
            return Created("https://localhost:44300/Order", flightrate);
            //return Ok(_mapper.Map<OrderViewModel>(Order));
        }

        /// <summary>
        /// order status update as Confirmed and available flights will reduce from flit rate table and send message to respective customer
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        [HttpPut]
        public async Task<IActionResult> Confirm([FromBody] UpdateOrderCommand command)
        {
            var flightrate = await _mediator.Send(command);
            //return Ok(flightrate);
            return Created("https://localhost:44300/Order", flightrate);
            //return Ok(_mapper.Map<OrderViewModel>(Order));
        }

    }
}
