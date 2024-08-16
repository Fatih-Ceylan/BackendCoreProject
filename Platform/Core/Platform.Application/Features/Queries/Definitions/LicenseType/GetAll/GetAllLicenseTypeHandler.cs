using MediatR;
using Platform.Application.Repositories.ReadRepository.Definitions;
using Platform.Application.VMs.Definitions.LicenseType;

namespace Platform.Application.Features.Queries.Definitions.LicenseType.GetAll
{
    public class GetAllLicenseTypeHandler : IRequestHandler<GetAllLicenseTypeRequest, GetAllLicenseTypeResponse>
    {
        readonly ILicenseTypeReadRepository _licenseTypeReadRepository;

        public GetAllLicenseTypeHandler(ILicenseTypeReadRepository licenseTypeReadRepository)
        {
            _licenseTypeReadRepository = licenseTypeReadRepository;
        }

        public async Task<GetAllLicenseTypeResponse> Handle(GetAllLicenseTypeRequest request, CancellationToken cancellationToken)
        {
            var query = _licenseTypeReadRepository
                        .GetAllDeletedStatusDesc(false, request.IsDeleted)
                        .Select(lt => new LicenseTypeVM
                        {
                            Id = lt.Id.ToString(),
                            Name = lt.Name,
                            UsageMounth = lt.UsageMounth,
                            UserNumber = lt.UserNumber,
                            CompanyNumber = lt.CompanyNumber,
                            CreatedDate = lt.CreatedDate,
                        });

            var totalCount = query.Count();
            var licenseTypes = request.DoPagination ? query.Skip(request.Page * request.Size)
                                                           .Take(request.Size).ToList()
                                                    : query.ToList();

            return new()
            {
                TotalCount = totalCount,
                LicenseTypes = licenseTypes,
            };
        }
    }
}