using API.Application.ViewModels;
using AutoMapper;
using Domain.Aggregates.FlightAggregate;
using Domain.Aggregates.OrderAggregate;
using Domain.Common;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace API.Application.Commands
{
    public class CreateOrderCommandHandlercs : IRequestHandler<CreateOrderCommand, OrderViewModel>
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IFlightRateRepository _flightRateRepository;
        private readonly IMapper _mapper;

        public CreateOrderCommandHandlercs(IOrderRepository orderRepository, IFlightRateRepository flightRateRepository, IMapper mapper)
        {
            _orderRepository = orderRepository;
            _flightRateRepository = flightRateRepository;
            _mapper = mapper;
        }

        /// <summary>
        /// system will get the user input get the flight rate from flight rate table and create the order
        /// </summary>
        /// <param name="request">CustomerId,FlightId,FlightRateId,Quantity></param>
        /// <param name="cancellationToken"></param>
        /// <returns>inserted ordre with line amount and total</returns>
        public async Task<OrderViewModel> Handle(CreateOrderCommand request, CancellationToken cancellationToken)
        {
            //get flight rate amount by flight rate id
            FlightRate f = await _flightRateRepository.GetAsync(request.FlightRateId);

            var Order = _orderRepository.Add(new Order(request.CustomerId, request.FlightId,request.FlightRateId,  (short)OrderStatus.Draft, request.Quantity, f.Price.Value));
            await _orderRepository.UnitOfWork.SaveEntitiesAsync();
            
            //map order object to order view and set the total
            OrderViewModel orderObj = _mapper.Map<OrderViewModel>(Order);
            orderObj.SetTotal();
            return orderObj;
        }
    }
}
