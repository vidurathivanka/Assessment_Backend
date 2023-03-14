using API.Application.ViewModels; 
using MediatR;
using System;

namespace API.Application.Commands
{
    public class UpdateOrderCommand : IRequest<OrderViewModel>
    {
        public Guid Id { get; private set; }

        public UpdateOrderCommand(Guid id)
        {
            Id = id; 
        }
    }
}
