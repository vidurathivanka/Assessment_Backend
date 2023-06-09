﻿using API.ApiResponses;
using API.Application.Queries;
using API.Application.ViewModels;
using AutoMapper;
using Domain.Aggregates.CustomerAggregate;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace API.Application.Commands
{
    public class GetCustomerHandler : IRequestHandler<GetCustomerQuery, List<CustomerViewModel>>
    {  
        private readonly ICustomerRepository _customerRepository;
        private readonly IMapper _mapper;
        public GetCustomerHandler(ICustomerRepository customerRepository, IMapper mapper)
        {
            _customerRepository = customerRepository;
            _mapper = mapper;
        }

        /// <summary>
        /// return the customer data based on the search string, this will check with first name and last name 
        /// if contains any matching string
        /// </summary>
        /// <param name="request">String</param>
        /// <param name="cancellationToken"></param>
        /// <returns>customer detail list</returns>
        public async Task<List<CustomerViewModel>> Handle(GetCustomerQuery request, CancellationToken cancellationToken)
        {
            List<CustomerViewModel> customerSearchedList = new List<CustomerViewModel>();
            var customerList = await _customerRepository.GetbyNameAsync(request.name);
            if (customerList != null && customerList.Count > 0)
            {
                foreach(Customer c in customerList)
                {
                    customerSearchedList.Add( _mapper.Map<CustomerViewModel>(c));
                }
            }
            return customerSearchedList;
        }
    }
}
