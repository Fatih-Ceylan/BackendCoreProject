using MediatR;

namespace GControl.Application.Features.Commands.Definitions.ShiftManagementIsActiveStatus
{
    public class ShiftManagementIsActiveStatusRequest : IRequest<ShiftManagementIsActiveStatusResponse>
    {
        public string Id { get; set; }
        public bool isActive { get; set; }
    }
}
