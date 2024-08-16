using MediatR;

namespace GControl.Application.Features.Commands.Definitions.EmployeeIsActiveStatus
{
    public class EmployeeIsActiveStatusRequest : IRequest<EmployeeIsActiveStatusResponse>
    {
        public string Id { get; set; }
        public bool isActive { get; set; }
    }
}
