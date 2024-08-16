using MediatR;

namespace GCrm.Application.Features.Commands.Definitions.CompanyOffer.Update
{
    public  class UpdateCompanyOfferRequest : IRequest<UpdateCompanyOfferResponse>
    {
        public string Id { get; set; }
        public string Name { get; set; }
    
    }
}
