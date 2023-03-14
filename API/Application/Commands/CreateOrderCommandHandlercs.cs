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
        public async Task<OrderViewModel> Handle(CreateOrderCommand request, CancellationToken cancellationToken)
        {
            FlightRate f = await _flightRateRepository.GetAsync(request.FlightRateId);
            var Order = _orderRepository.Add(new Order(request.CustomerId, request.FlightId,request.FlightRateId,  (short)OrderStatus.Draft, request.Quantity, f.Price.Value));

            await _orderRepository.UnitOfWork.SaveEntitiesAsync();
            OrderViewModel orderObj = _mapper.Map<OrderViewModel>(Order);
            orderObj.SetTotal();
            return orderObj;
        }
    }
}
