using MediatR;
using Utilities.Core.UtilityApplication.RequestParameters;

namespace NLLogistics.Application.Features.Queries.Definitions.Port.GetAll
{
    public class GetAllPortRequest: Pagination, IRequest<GetAllPortResponse>
    {

    }
}