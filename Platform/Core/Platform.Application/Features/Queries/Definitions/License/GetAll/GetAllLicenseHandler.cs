using MediatR;
using Platform.Application.Repositories.ReadRepository.Definitions;
using Platform.Application.VMs.Definitions.License;

namespace Platform.Application.Features.Queries.Definitions.License.GetAll
{
    public class GetAllLicenseHandler : IRequestHandler<GetAllLicenseRequest, GetAllLicenseResponse>
    {
        readonly ILicenseReadRepository _licenseReadRepository;

        public GetAllLicenseHandler(ILicenseReadRepository licenseReadRepository)
        {
            _licenseReadRepository = licenseReadRepository;
        }

        public Task<GetAllLicenseResponse> Handle(GetAllLicenseRequest request, CancellationToken cancellationToken)
        {
            var query = _licenseReadRepository
                                  .GetAllDeletedStatusDesc(false, request.IsDeleted)
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
                                      RemainingUsageDays = (l.ExpirationDate - DateTime.Now).Days > 0 ? (l.ExpirationDate - DateTime.Now).Days : 0,
                                      TotalUserNumber = l.TotalUserNumber,
                                      TotalCompanyNumber = l.TotalCompanyNumber,
                                      CreatedDate = l.CreatedDate
                                  });

            var totalCount = query.Count();
            var licenses = request.DoPagination ? query.Skip(request.Page * request.Size)
                                                       .Take(request.Size).ToList()
                                                : query.ToList();

            return Task.FromResult(new GetAllLicenseResponse
            {
                TotalCount = totalCount,
                Licenses = licenses,
            });
        }
    }
}