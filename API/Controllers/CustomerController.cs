using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using MediatR; 
using Microsoft.Extensions.Logging;
using API.Application.Commands;
using System.Threading.Tasks;
using API.Application.ViewModels;

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
         
    }
}
