using Domain.Aggregates.CustomerAggregate;
using Domain.Aggregates.FlightAggregate;
using Domain.Aggregates.OrderAggregate;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace API.Application.Commands
{
    public class UpdateFlightRateCommandHandler : IRequestHandler<UpdateFlightRateCommand, FlightRate>
    {
        private readonly IFlightRateRepository _flightRateRepository;
        private readonly IOrderRepository _orderRepository;

        public UpdateFlightRateCommandHandler(IFlightRateRepository flightRateRepository, IOrderRepository OrderRepository)
        {
            _flightRateRepository = flightRateRepository;
            _orderRepository = OrderRepository;
        }

        public async Task<FlightRate> Handle(UpdateFlightRateCommand request, CancellationToken cancellationToken)
        {

            var flightRate = await _flightRateRepository.GetAsync(request.Id);
            if (flightRate != null)
            {
                flightRate.ChangePrice(request.Price);
                _flightRateRepository.Update(flightRate);

                await _flightRateRepository.UnitOfWork.SaveChangesAsync();

                var orderList = await _orderRepository.GetOrderbyFlightRate(flightRate.Id);

                foreach (Order orderObj in orderList)
                {
                    orderObj.UpdateAmount(request.Price.Value);
                    _orderRepository.Update(orderObj);

                    // need to get user details from user repository
                    Console.WriteLine(orderObj.CustomerId + "  Dear sir, your Flight Rates has been change now");
                }

                await _orderRepository.UnitOfWork.SaveChangesAsync();
                return flightRate;
            }
            return flightRate;
        }

    }
}
