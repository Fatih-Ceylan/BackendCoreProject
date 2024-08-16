using GCrm.Application.Repositories.ReadRepository;
using GCrm.Application.VMs.Definitions;
using MediatR;

namespace GCrm.Application.Features.Queries.Definitions.CompanyContactName.GetById
{
    public class GetByIdCompanyContactNameHandler : IRequestHandler<GetByIdCompanyContactNameRequest, GetByIdCompanyContactNameResponse>
    {
        readonly ICompanyContactNameReadRepository _companyContactNameReadRepository;
        public GetByIdCompanyContactNameHandler(ICompanyContactNameReadRepository companyContactNameReadRepository)
        {
            _companyContactNameReadRepository = companyContactNameReadRepository;
        }

        public async Task<GetByIdCompanyContactNameResponse> Handle(GetByIdCompanyContactNameRequest request, CancellationToken cancellationToken)
        {
            var companyContactName = _companyContactNameReadRepository
                          .GetWhere(ck => ck.Id == Guid.Parse(request.Id), false)
                          .Select(ck => new CompanyContactNameVM
                          {
                              Id = ck.Id.ToString(),
                              Name = ck.Name
                          }).FirstOrDefault();

            return new()
            {
                CompanyContactName = companyContactName
            };
        }
    }
}
