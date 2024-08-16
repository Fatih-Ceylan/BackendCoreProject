using MediatR;
using Utilities.Core.UtilityApplication.RequestParameters;

namespace GCrm.Application.Features.Queries.Definitions.CompanyOffer.GetAll
{
    public  class GetAllCompanyOfferRequest : Pagination, IRequest<GetAllCompanyOfferResponse>
    {
    }
}
