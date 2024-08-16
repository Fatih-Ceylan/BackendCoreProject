﻿using MediatR;

namespace HR.Application.Features.Commands.Identity.Employee.Login
{
    public class LoginEmployeeRequest : IRequest<LoginEmployeeResponse>
    {
        public string UserName { get; set; }
        public string Password { get; set; }
    }
}
