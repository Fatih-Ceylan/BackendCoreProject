using MediatR;

namespace GControl.Application.Features.Commands.Definitions.ShiftManagement.Delete
{
    public class DeleteShiftManagementRequest : IRequest<DeleteShiftManagementResponse>
    {
        public string Id { get; set; }
    }
}
