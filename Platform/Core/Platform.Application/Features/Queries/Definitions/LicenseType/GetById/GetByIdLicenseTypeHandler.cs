using MediatR;
using Platform.Application.Repositories.ReadRepository.Definitions;
using Platform.Application.VMs.Definitions.LicenseType;

namespace Platform.Application.Features.Queries.Definitions.LicenseType.GetById
{
    public class GetByIdLicenseTypeHandler : IRequestHandler<GetByIdLicenseTypeRequest, GetByIdLicenseTypeResponse>
    {
        readonly ILicenseTypeReadRepository _licenseTypeReadRepository;

        public GetByIdLicenseTypeHandler(ILicenseTypeReadRepository licenseTypeReadRepository)
        {
            _licenseTypeReadRepository = licenseTypeReadRepository;
        }

        public async Task<GetByIdLicenseTypeResponse> Handle(GetByIdLicenseTypeRequest request, CancellationToken cancellationToken)
        {
            var licenseType = _licenseTypeReadRepository
                             .GetWhere(lt => lt.Id == Guid.Parse(request.Id))
                              .Select(lt => new LicenseTypeVM
                              {
                                  Id = lt.Id.ToString(),
                                  Name = lt.Name,
                                  UsageMounth = lt.UsageMounth,
                                  UserNumber = lt.UserNumber,
                                  CompanyNumber = lt.CompanyNumber,
                                  CreatedDate = lt.CreatedDate,
                              }).FirstOrDefault();

            return new()
            {
                LicenseType = licenseType,
            };
        }
    }
}