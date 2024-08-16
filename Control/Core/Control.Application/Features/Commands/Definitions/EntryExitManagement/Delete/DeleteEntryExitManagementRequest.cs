using MediatR;

namespace GControl.Application.Features.Commands.Definitions.EntryExitManagement.Delete
{
    public class DeleteEntryExitManagementRequest : IRequest<DeleteEntryExitManagementResponse>
    {
        public string Id { get; set; }
    }
}
