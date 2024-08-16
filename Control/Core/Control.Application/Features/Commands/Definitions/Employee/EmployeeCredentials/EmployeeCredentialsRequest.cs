using MediatR;

namespace GControl.Application.Features.Commands.Definitions.Employee.EmployeeCredentials
{
    public class EmployeeCredentialsRequest : IRequest<EmployeeCredentialsResponse>
    {
        public string Id { get; set; }
        //public string? CompanyId { get; set; }
    }
}
