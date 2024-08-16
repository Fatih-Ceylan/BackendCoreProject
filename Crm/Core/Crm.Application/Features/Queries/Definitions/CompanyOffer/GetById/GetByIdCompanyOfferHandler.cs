using GCrm.Application.Repositories.ReadRepository;
using GCrm.Application.VMs.Definitions;
using MediatR;

namespace GCrm.Application.Features.Queries.Definitions.CompanyOffer.GetById
{
    public class GetByIdCompanyOfferHandler : IRequestHandler<GetByIdCompanyOfferRequest, GetByIdCompanyOfferResponse>
    {
        readonly ICompanyOfferReadRepository _companyOfferReadRepository ;
        public GetByIdCompanyOfferHandler(ICompanyOfferReadRepository companyOfferReadRepository)
        {
            _companyOfferReadRepository= companyOfferReadRepository;

        }
        public async  Task<GetByIdCompanyOfferResponse> Handle(GetByIdCompanyOfferRequest request, CancellationToken cancellationToken)
        {
            var companyOffer = _companyOfferReadRepository
                           .GetWhere(ck => ck.Id == Guid.Parse(request.Id), false)
                           .Select(ck => new CompanyOfferVM
                           {
                               Id = ck.Id.ToString(),
                               Name = ck.Name
                           }).FirstOrDefault();

            return new()
            {
                CompanyOffer = companyOffer
            };
        }
    }
}
