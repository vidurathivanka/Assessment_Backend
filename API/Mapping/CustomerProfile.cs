using API.ApiResponses;
using API.Application.ViewModels;
using AutoMapper;
using Domain.Aggregates.CustomerAggregate;

namespace API.Mapping
{
    public class CustomerProfile : Profile
    {
        public CustomerProfile()
        {
            CreateMap<Customer, CustomerViewModel>();
            CreateMap<Customer, CustomerResponse>();
            CreateMap<CustomerResponse, CustomerViewModel>();
        }
    }
}
