using BaseProject.Application.Repositories.ReadRepository.Definitions;
using BaseProject.Application.VMs.Definitions.CompanyLicense;
using BaseProject.Domain.Entities.Definitions;
using MediatR;
using System.Linq.Expressions;

namespace BaseProject.Application.Features.Queries.Definitions.Company.GetAllCompanyLicenses
{
    public class GetAllCompanyLicensesHandler : IRequestHandler<GetAllCompanyLicensesRequest, GetAllCompanyLicensesResponse>
    {
        readonly ICompanyLicenseReadRepository _companyLicenseReadRepository;

        public GetAllCompanyLicensesHandler(ICompanyLicenseReadRepository companyLicenseReadRepository)
        {
            _companyLicenseReadRepository = companyLicenseReadRepository;
        }

        public async Task<GetAllCompanyLicensesResponse> Handle(GetAllCompanyLicensesRequest request, CancellationToken cancellationToken)
        {
            Expression<Func<CompanyLicense, bool>> licenseFilter = cl => request.LicenseIds.Contains(cl.LicenseId.ToString());
            var companyLicensesQuery = _companyLicenseReadRepository.GetAllDeletedStatus(false, false)
                                                                    .Where(cl => cl.CompanyId == Guid.Parse(request.CompanyId));
            companyLicensesQuery = companyLicensesQuery.Where(licenseFilter);

            var companyLicenses = companyLicensesQuery.Select(li => new CompanyLicenseCreateVM
            {
                LicenseId = li.LicenseId.ToString(),
                IsInUse = li.IsInUse,
            }).ToList();

            return new()
            {
                TotalCount = companyLicenses.Count,
                CompanyLicenses = companyLicenses,
            };
        }
    }
}