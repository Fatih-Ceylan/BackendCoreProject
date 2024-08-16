using MediatR;

namespace GCrm.Application.Features.Queries.Definitions.CompanyOffer.GetById
{
    public class GetByIdCompanyOfferRequest : IRequest<GetByIdCompanyOfferResponse>
    {
        public string Id { get; set; }
    }
}