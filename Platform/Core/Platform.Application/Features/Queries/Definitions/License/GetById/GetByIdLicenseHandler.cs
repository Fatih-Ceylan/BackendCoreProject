using MediatR;
using Platform.Application.Repositories.ReadRepository.Definitions;
using Platform.Application.VMs.Definitions.License;

namespace Platform.Application.Features.Queries.Definitions.License.GetById
{
    public class GetByIdLicenseHandler : IRequestHandler<GetByIdLicenseRequest, GetByIdLicenseResponse>
    {
        readonly ILicenseReadRepository _licenseReadRepository;

        public GetByIdLicenseHandler(ILicenseReadRepository licenseReadRepository)
        {
            _licenseReadRepository = licenseReadRepository;
        }

        public async Task<GetByIdLicenseResponse> Handle(GetByIdLicenseRequest request, CancellationToken cancellationToken)
        {
            var license = _licenseReadRepository
                         .GetWhere(l => l.Id == Guid.Parse(request.Id), false)
                              .Select(l => new LicenseVM
                              {
                                  Id = l.Id.ToString(),
                                  CompanyId = l.CompanyId.ToString(),
                                  CompanyName = l.Company.Name,
                                  GModuleId = l.GModuleId.ToString(),
                                  GModuleName = l.GModule.Name,
                                  LicenseTypeId = l.LicenseTypeId.ToString(),
                                  LicenseTypeName = l.LicenseType.Name,
                                  LicenseKey = l.LicenseKey.ToString(),
                                  StartDate = l.StartDate,
                                  ExpirationDate = l.ExpirationDate,
                                  TotalUserNumber = l.TotalUserNumber,
                                  RemainingUsageDays = (l.ExpirationDate - DateTime.Now).Days > 0 ? (l.ExpirationDate - DateTime.Now).Days : 0,
                                  TotalCompanyNumber = l.TotalCompanyNumber,
                                  CreatedDate = l.CreatedDate
                              }).FirstOrDefault();

            return new()
            {
                License = license
            };
        }
    }
}