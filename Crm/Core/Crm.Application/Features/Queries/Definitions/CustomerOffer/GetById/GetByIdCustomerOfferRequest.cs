using MediatR;

namespace GCrm.Application.Features.Queries.Definitions.CustomerOffer.GetById
{
    public  class GetByIdCustomerOfferRequest : IRequest<GetByIdCustomerOfferResponse>
    {
        public string Id { get; set; }
    }
}
