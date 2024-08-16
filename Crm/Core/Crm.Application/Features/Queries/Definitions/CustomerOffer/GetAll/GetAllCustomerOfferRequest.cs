using MediatR;
using Utilities.Core.UtilityApplication.RequestParameters;

namespace GCrm.Application.Features.Queries.Definitions.CustomerOffer.GetAll
{
    public  class GetAllCustomerOfferRequest : Pagination, IRequest<GetAllCustomerOfferResponse>
    {
        public string   Id { get; set; }
    }
}
