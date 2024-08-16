using MediatR;

namespace Card.Application.Features.Queries.Definitions.StaffFile.GetById
{
    public class GetByIdStaffFileRequest : IRequest<GetByIdStaffFileResponse>
    {
        public string Id { get; set; }
    }
}
