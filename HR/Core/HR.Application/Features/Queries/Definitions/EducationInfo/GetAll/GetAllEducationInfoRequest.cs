using MediatR;
using Utilities.Core.UtilityApplication.RequestParameters;

namespace HR.Application.Features.Queries.Definitions.EducationInfo.GetAll
{
    public class GetAllEducationInfoRequest : Pagination, IRequest<GetAllEducationInfoResponse>

    {
    }
}
