using GCrm.Application.Repositories.ReadRepository;
using GCrm.Application.VMs.Definitions;
using MediatR;

namespace GCrm.Application.Features.Queries.Definitions.CompanyTender.GetAll
{
    public class GetAllCompanyTenderHandler : IRequestHandler<GetAllCompanyTenderRequest, GetAllCompanyTenderResponse>
    {
        readonly ICompanyTenderReadRepository _companyTenderReadRepository;

        public GetAllCompanyTenderHandler(ICompanyTenderReadRepository companyTenderReadRepository)
        {
            _companyTenderReadRepository = companyTenderReadRepository;
        }

        public Task<GetAllCompanyTenderResponse> Handle(GetAllCompanyTenderRequest request, CancellationToken cancellationToken)
        {
            var query = _companyTenderReadRepository
                         .GetAllDeletedStatusDesc(false)
                         .Select(ck => new CompanyTenderVM
                         {
                             Id = ck.Id.ToString(),
                             Name = ck.Name
                         });

            var totalCount = query.Count();
            var customerTenders = query.Skip(request.Page * request.Size)
                                 .Take(request.Size).ToList();

            return Task.FromResult(new GetAllCompanyTenderResponse
            {
                TotalCount = totalCount,
                CompanyTenders = customerTenders,
            });
        }
    }
}
