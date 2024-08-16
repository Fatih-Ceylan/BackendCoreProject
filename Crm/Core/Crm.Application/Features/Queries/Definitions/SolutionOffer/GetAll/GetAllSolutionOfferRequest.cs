using MediatR;
using Utilities.Core.UtilityApplication.RequestParameters;

namespace GCrm.Application.Features.Queries.Definitions.SolutionOffer.GetAll
{
    public  class GetAllSolutionOfferRequest :Pagination, IRequest<GetAllSolutionOfferResponse>
    {
    }
}
