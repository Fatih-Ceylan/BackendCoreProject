using BaseProject.Application.Repositories.ReadRepository.Definitions;
using BaseProject.Application.VMs.Definitions.AppUserLicense;
using BaseProject.Domain.Entities.Definitions;
using MediatR;
using System.Linq.Expressions;

namespace BaseProject.Application.Features.Queries.Identity.AppUser.GetAllAppUserLicenses
{
    public class GetAllAppUserLicensesHandler : IRequestHandler<GetAllAppUserLicensesRequest, GetAllAppUserLicensesResponse>
    {
        readonly IAppUserLicenseReadRepository _appUserLicenseReadRepository;

        public GetAllAppUserLicensesHandler(IAppUserLicenseReadRepository appUserLicenseReadRepository)
        {
            _appUserLicenseReadRepository = appUserLicenseReadRepository;
        }

        public async Task<GetAllAppUserLicensesResponse> Handle(GetAllAppUserLicensesRequest request, CancellationToken cancellationToken)
        {
            Expression<Func<AppUserLicense, bool>> licenseFilter = cl => request.LicenseIds.Contains(cl.LicenseId.ToString());
            var appUserLicensesQuery = _appUserLicenseReadRepository.GetAllDeletedStatus(false, false)
                                                                    .Where(cl => cl.AppUserId == request.AppUserId);
            appUserLicensesQuery = appUserLicensesQuery.Where(licenseFilter);

            var appUserLicenses = appUserLicensesQuery.Select(li => new AppUserLicenseCreateVM
            {
                LicenseId = li.LicenseId.ToString(),
                IsInUse = li.IsInUse,
            }).ToList();

            return new()
            {
                TotalCount = appUserLicenses.Count,
                AppUserLicenses = appUserLicenses,
            };
        }
    }
}