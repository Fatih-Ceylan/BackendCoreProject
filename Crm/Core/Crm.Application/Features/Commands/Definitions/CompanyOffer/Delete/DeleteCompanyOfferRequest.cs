using MediatR;

namespace GCrm.Application.Features.Commands.Definitions.CompanyOffer.Delete
{
    public  class DeleteCompanyOfferRequest : IRequest<DeleteCompanyOfferResponse>
    {
        public string Id { get; set; }
    }
}
