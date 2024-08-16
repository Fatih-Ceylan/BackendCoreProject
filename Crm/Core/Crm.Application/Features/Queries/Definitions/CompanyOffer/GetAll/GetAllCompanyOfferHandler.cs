using GCrm.Application.Repositories.ReadRepository;
using GCrm.Application.VMs.Definitions;
using MediatR;

namespace GCrm.Application.Features.Queries.Definitions.CompanyOffer.GetAll
{
    public class GetAllCompanyOfferHandler : IRequestHandler<GetAllCompanyOfferRequest, GetAllCompanyOfferResponse>
    {
        readonly ICompanyOfferReadRepository _companyOfferReadRepository;

        public GetAllCompanyOfferHandler(ICompanyOfferReadRepository companyOfferReadRepository)
        {
            _companyOfferReadRepository= companyOfferReadRepository;

        }

        public Task<GetAllCompanyOfferResponse> Handle(GetAllCompanyOfferRequest request, CancellationToken cancellationToken)
        {
            var query = _companyOfferReadRepository
                       .GetAllDeletedStatusDesc(false)
                       .Select(ck => new CompanyOfferVM
                       {
                           Id = ck.Id.ToString(),
                           Name = ck.Name
                       });

            var totalCount = query.Count();
            var companyOffers = query.Skip(request.Page * request.Size)
                                 .Take(request.Size).ToList();

            return Task.FromResult(new GetAllCompanyOfferResponse
            {
                TotalCount = totalCount,
                CompanyOffers = companyOffers,
            });
        }
    }
}
