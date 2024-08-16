using MediatR;

namespace HR.Application.Features.Queries.Definitions.Leave.GetById
{
    public class GetByIdLeaveRequest : IRequest<GetByIdLeaveResponse>
    {
        public string Id { get; set; }
    }
}
