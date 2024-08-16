using MediatR;
using Utilities.Core.UtilityApplication.RequestParameters;

namespace NLLogistics.Application.Features.Queries.Definitions.Voyage.GetAll
{
    public class GetAllVoyageRequest: Pagination, IRequest<GetAllVoyageResponse>
    {

    }
}