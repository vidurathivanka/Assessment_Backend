using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using MediatR; 
using Microsoft.Extensions.Logging;
using API.Application.Commands;
using System.Threading.Tasks;
using API.Application.ViewModels;
using API.ApiResponses;
using System.Collections.Generic;
using API.Application.Queries;

namespace API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CustomerController : ControllerBase
    {
        private readonly ILogger<CustomerController> _logger;
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;
        public CustomerController(
               ILogger<CustomerController> logger,
               IMediator mediator,
               IMapper mapper)
        {
            _logger = logger;
            _mediator = mediator;
            _mapper = mapper;
        }
        [HttpPost]
        public async Task<IActionResult> Store([FromBody] CreateCustomerCommand command)
        {
            var customer = await _mediator.Send(command);
            return Ok(customer);
            //return Ok(_mapper.Map<CustomerViewModel>(customer));
        }

        /// <summary>
        /// Search from customer table contains first name or last name 
        /// </summary>
        /// <param name="name"></param>
        /// <returns>customer details</returns>
        [HttpGet("{name}")]
        public async Task<IActionResult> GetCustomer(string name)
        {
            var customer = await _mediator.Send(new GetCustomerQuery(name));
            // return Ok(_mapper.Map<FlightResponse>(flight));
            if(customer.Count == 0)
            {
                return StatusCode(500, new { error = "There is no customer with searched name" });
            }
            return  Ok(customer);

        }

    }
}
