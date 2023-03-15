using Domain.Aggregates.FlightAggregate;
using Domain.Aggregates.OrderAggregate;
using Domain.Common;
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

        /// <summary>
        /// Update flight rate and update the respective draft ordre's line amount
        /// </summary>
        /// <param name="request">FlightRate ID, amount</param>
        /// <param name="cancellationToken"></param>
        /// <returns>updated fkight rate id, give message to the customer who has draft order for paticular flight rate</returns>
        public async Task<FlightRate> Handle(UpdateFlightRateCommand request, CancellationToken cancellationToken)
        {
            //get flight rate details
            var flightRate = await _flightRateRepository.GetAsync(request.Id);
            if (flightRate != null)
            {
                //update the price
                flightRate.ChangePrice(request.Price, Currency.EUR);
                _flightRateRepository.Update(flightRate);

                await _flightRateRepository.UnitOfWork.SaveChangesAsync();

                //get the ordre details by flight rate id
                var orderList = await _orderRepository.GetDraftOrderbyFlightRate(flightRate.Id);

                foreach (Order orderObj in orderList)
                {
                    //update the order's line amount
                    orderObj.UpdateAmount(request.Price);
                    _orderRepository.Update(orderObj);

                    //send message to the customer who has draft ordres that flight rates has been updated
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
