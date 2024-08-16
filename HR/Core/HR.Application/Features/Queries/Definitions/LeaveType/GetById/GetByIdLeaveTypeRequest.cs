using MediatR;

namespace HR.Application.Features.Queries.Definitions.LeaveType.GetById
{
    public class GetByIdLeaveTypeRequest : IRequest<GetByIdLeaveTypeResponse>
    {
        public string Id { get; set; }
    }
}
