using MediatR;

namespace GCrm.Application.Features.Commands.Definitions.CompanyOffer.Create
{
    public  class CreateCompanyOfferRequest : IRequest<CreateCompanyOfferResponse>
    {
        public string Name { get; set; }
    }
}
