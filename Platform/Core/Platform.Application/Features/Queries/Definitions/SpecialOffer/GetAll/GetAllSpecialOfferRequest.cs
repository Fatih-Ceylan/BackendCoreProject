using MediatR;
using Utilities.Core.UtilityApplication.RequestParameters;

namespace Platform.Application.Features.Queries.Definitions.SpecialOffer.GetAll
{
    public class GetAllSpecialOfferRequest : Pagination, IRequest<GetAllSpecialOfferResponse>
    {
    }
}
