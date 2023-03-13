using Domain.Aggregates.OrderAggregate;
using MediatR;
using System;

namespace API.Application.Commands
{
    public class UpdateOrderCommand : IRequest<Order>
    {
        public Guid Id { get; private set; }
        public Int16 Status { get; private set; }

        public UpdateOrderCommand(Guid id)
        {
            Id = id; 
        }
    }
}
