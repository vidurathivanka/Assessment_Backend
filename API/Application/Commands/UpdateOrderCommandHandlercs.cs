using API.Application.ViewModels;
using AutoMapper;
using Domain.Aggregates.FlightAggregate;
using Domain.Aggregates.OrderAggregate;
using Domain.Common;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace API.Application.Commands
{
    public class UpdateOrderCommandHandlercs : IRequestHandler<UpdateOrderCommand, OrderViewModel>
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IFlightRateRepository _flightRateRepository;
        private readonly IMapper _mapper;

        public UpdateOrderCommandHandlercs(IOrderRepository orderRepository, IFlightRateRepository flightRateRepository,IMapper mapper)
        {
            _orderRepository = orderRepository;
            _flightRateRepository = flightRateRepository;
            _mapper = mapper;
        }

        /// <summary>
        /// Submit the ordre/ change the status of the ordre to submit then reduce the availability of the respective flight rates
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken">Ordre ID</param>
        /// <returns>Updated ordre details/ send message to the customer as "ordre is confirm"</returns>
        public async Task<OrderViewModel> Handle(UpdateOrderCommand request, CancellationToken cancellationToken)
        {
            //get ordre details by irdre id
            var Order = await _orderRepository.GetAsync(request.Id);
            if (Order != null && Order.Status == (short)OrderStatus.Draft)
            {
                //set ordre status as confirmed
                Order.UpdateStatus((short)OrderStatus.Confirmed);
                _orderRepository.Update(Order);

                //send message to the customer
                // need to get user details from user repository
                Console.WriteLine(Order.CustomerId + "  Dear sir, your Flight booking is Confirm");

                //get flight rate details by flight rate id
                var flightRate = await _flightRateRepository.GetAsync(Order.FlightRateId);
                if (flightRate != null)
                {
                    //reduce availability by ordred quantity 
                    flightRate.ReduceAvailability(Order.Quantity);
                    _flightRateRepository.Update(flightRate);

                    await _flightRateRepository.UnitOfWork.SaveEntitiesAsync();
                }
                await _orderRepository.UnitOfWork.SaveEntitiesAsync();
            }

            //map updated model to view model and calculate the total
            OrderViewModel orderObj = _mapper.Map<OrderViewModel>(Order);
            orderObj.SetTotal();
            return orderObj;
        }
    
    }
}
