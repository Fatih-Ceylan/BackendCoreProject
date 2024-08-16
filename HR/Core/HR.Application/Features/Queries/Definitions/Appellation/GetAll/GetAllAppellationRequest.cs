using MediatR;
using Utilities.Core.UtilityApplication.RequestParameters;

namespace HR.Application.Features.Queries.Definitions.Appellation.GetAll
{
    public class GetAllAppellationRequest : Pagination, IRequest<GetAllAppellationResponse>
    {
    }
}
