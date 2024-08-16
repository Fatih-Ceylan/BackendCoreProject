using MediatR;

namespace GControl.Application.Features.Queries.Definitions.EntryExitManagement.GetById
{
    public class GetByIdEntryExitManagementRequest : IRequest<GetByIdEntryExitManagementResponse>
    {
        public string Id { get; set; }
    }
}
