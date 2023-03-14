using MediatR;
using System;

namespace API.ApiResponses;
    
public record CustomerResponse(Guid CustomerId ,string FirstName , string LastName, DateTime DateOfBirth);


