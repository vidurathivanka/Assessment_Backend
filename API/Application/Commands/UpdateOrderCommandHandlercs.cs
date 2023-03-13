using Domain.Aggregates.FlightAggregate;
using Domain.Aggregates.OrderAggregate;
using Domain.Common;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace API.Application.Commands
{
    public class UpdateOrderCommandHandlercs : IRequestHandler<UpdateOrderCommand, Order>
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IFlightRateRepository _flightRateRepository;

        public UpdateOrderCommandHandlercs(IOrderRepository orderRepository, IFlightRateRepository flightRateRepository)
        {
            _orderRepository = orderRepository;
            _flightRateRepository = flightRateRepository;
        }

        public async Task<Order> Handle(UpdateOrderCommand request, CancellationToken cancellationToken)
        {
            var Order = await _orderRepository.GetAsync(request.Id);
            if (Order != null && Order.Status == (short)OrderStatus.Draft)
            {
                Order.UpdateStatus((short)OrderStatus.Confirmed);
                _orderRepository.Update(Order);

                // need to get user details from user repository
                Console.WriteLine(Order.CustomerId + "  Dear sir, your Flight booking is Confirm");

                var flightRate = await _flightRateRepository.GetAsync(Order.FlightRateId);
                if (flightRate != null)
                {
                    flightRate.ReduceAvailability(Order.Quantity);
                    _flightRateRepository.Update(flightRate);

                    await _orderRepository.UnitOfWork.SaveEntitiesAsync();
                }

            }

            return Order;
        }
    
    }
}
