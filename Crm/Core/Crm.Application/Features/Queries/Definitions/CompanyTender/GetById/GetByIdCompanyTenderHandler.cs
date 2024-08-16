using GCrm.Application.Repositories.ReadRepository;
using GCrm.Application.VMs.Definitions;
using MediatR;

namespace GCrm.Application.Features.Queries.Definitions.CompanyTender.GetById
{
    public class GetByIdCompanyTenderHandler : IRequestHandler<GetByIdCompanyTenderRequest, GetByIdCompanyTenderResponse>
    {
        readonly ICompanyTenderReadRepository _companyTenderReadRepository;
        public GetByIdCompanyTenderHandler(ICompanyTenderReadRepository companyTenderReadRepository)
        {
            _companyTenderReadRepository = companyTenderReadRepository;
        }

        public async  Task<GetByIdCompanyTenderResponse> Handle(GetByIdCompanyTenderRequest request, CancellationToken cancellationToken)
        {
            var companyTender = _companyTenderReadRepository
                          .GetWhere(ck => ck.Id == Guid.Parse(request.Id), false)
                          .Select(ck => new CompanyTenderVM
                          {
                              Id = ck.Id.ToString(),
                              Name = ck.Name
                          }).FirstOrDefault();

            return new()
            {
                CompanyTender = companyTender
            };
        }
    }
}
