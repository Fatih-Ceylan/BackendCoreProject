using MediatR;
using Utilities.Core.UtilityApplication.RequestParameters;

namespace HR.Application.Features.Queries.Definitions.Leave.GetAll
{
    public class GetAllLeaveRequest : Pagination, IRequest<GetAllLeaveResponse>
    {
    }
}
