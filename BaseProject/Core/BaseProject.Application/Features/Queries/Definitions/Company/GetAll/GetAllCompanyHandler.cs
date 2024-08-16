using BaseProject.Application.Repositories.ReadRepository.Definitions;
using BaseProject.Application.VMs.Definitions.Company;
using BaseProject.Application.VMs.Definitions.CompanyLicense;
using MediatR;

namespace BaseProject.Application.Features.Queries.Definitions.Company.GetAll
{
    public class GetAllCompanyHandler : IRequestHandler<GetAllCompanyRequest, GetAllCompanyResponse>
    {
        readonly ICompanyReadRepository _companyReadRepository;

        public GetAllCompanyHandler(ICompanyReadRepository companyReadRepository)
        {
            _companyReadRepository = companyReadRepository;
        }

        public Task<GetAllCompanyResponse> Handle(GetAllCompanyRequest request, CancellationToken cancellationToken)
        {
            var mainCompany = _companyReadRepository.GetWhere(mc => mc.MainCompanyId == null).FirstOrDefault();

            var query = _companyReadRepository.GetAllDeletedStatusIncludingDesc([c => c.CompanyLicenses], false, request.IsDeleted)
                .Select(c => new CompanyVM
                {
                    Id = c.Id.ToString(),
                    MainCompanyId = c.MainCompanyId.ToString(),
                    MainCompanyName = mainCompany.Name,
                    LogoPath = c.LogoPath,
                    Name = c.Name,
                    AuthorizedFullName = c.AuthorizedFullName,
                    PhoneNumber = c.PhoneNumber,
                    FaxNo = c.FaxNo,
                    Email = c.Email,
                    WebAddress = c.WebAddress,
                    TaxOffice = c.TaxOffice,
                    TaxNo = c.TaxNo,
                    TradeRegisterNo = c.TradeRegisterNo,
                    SocialSecurityNo = c.SocialSecurityNo,
                    MersisNo = c.MersisNo,
                    CompanyLicenses = c.CompanyLicenses.Select(cl => new CompanyLicenseCreateVM
                    {
                        LicenseId = cl.LicenseId.ToString(),
                        IsInUse = cl.IsInUse
                    }).ToList(),
                    CreatedDate = c.CreatedDate,
                });

            var totalCount = query.Count();
            var companies = request.DoPagination ? query.Skip(request.Page * request.Size)
                                                        .Take(request.Size)
                                                        .ToList()
                                                 : query.ToList();

            return Task.FromResult(new GetAllCompanyResponse
            {
                TotalCount = totalCount,
                Companies = companies,
            });
        }
    }
}