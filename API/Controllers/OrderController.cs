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

        [HttpPost]
        public async Task<IActionResult> Store([FromBody] CreateOrderCommand command)
        {
            var customer = await _mediator.Send(command);
            return Ok(customer);
            //return Ok(_mapper.Map<OrderViewModel>(Order));
        }

        [HttpPut]
        public async Task<IActionResult> Confirm([FromBody] UpdateOrderCommand command)
        {
            var flightrate = await _mediator.Send(command);
            return Ok(flightrate);
            //return Ok(_mapper.Map<OrderViewModel>(Order));
        }

    }
}
