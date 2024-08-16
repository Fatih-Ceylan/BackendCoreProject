using MediatR;

namespace Card.Application.Features.Commands.Definitions.StaffFile.Delete
{
    public class DeleteStaffFileRequest : IRequest<DeleteStaffFileResponse>
    {
        public string Id { get; set; } 
    }
}
