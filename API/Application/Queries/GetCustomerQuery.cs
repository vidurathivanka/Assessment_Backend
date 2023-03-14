using API.Application.ViewModels;
using MediatR;
using System.Collections.Generic;

namespace API.Application.Queries
{
    public record GetCustomerQuery(string name) : IRequest<List<CustomerViewModel>>;
}
