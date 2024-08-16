using MediatR;

namespace GControl.Application.Features.Commands.Definitions.DepartmentIsActiveStatus
{
    public class DepartmentIsActiveStatusRequest : IRequest<DepartmentIsActiveStatusResponse>
    {
        public string Id { get; set; }
        public bool isActive { get; set; }
    }
}
