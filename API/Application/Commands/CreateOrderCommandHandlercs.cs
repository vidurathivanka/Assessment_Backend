using Domain.Aggregates.OrderAggregate;
using Domain.Common;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace API.Application.Commands
{
    public class CreateOrderCommandHandlercs : IRequestHandler<CreateOrderCommand, Order>
    {
        private readonly IOrderRepository _orderRepository;

        public CreateOrderCommandHandlercs(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }

        public async Task<Order> Handle(CreateOrderCommand request, CancellationToken cancellationToken)
        {
            var customer = _orderRepository.Add(new Order(request.CustomerId, request.FlightId,request.FlightRateId, request.Amount, (short)OrderStatus.Draft, request.Quantity));

            await _orderRepository.UnitOfWork.SaveEntitiesAsync();

            return customer;
        }
    }
}
