using MediatR;
using Platform.Application.Repositories.ReadRepository.Definitions;
using Platform.Application.VMs.Definitions.GModule;
using Utilities.Core.UtilityApplication.Abstractions.Services.CurrentUser;

namespace Platform.Application.Features.Queries.Definitions.GModule.GetAllByCurrentCompanyId
{
    public class GetAllByCurrentCompanyIdHandler : IRequestHandler<GetAllByCurrentCompanyIdRequest, GetAllByCurrentCompanyIdResponse>
    {
        readonly IGModuleReadRepository _gModuleReadRepository;
        readonly ILicenseReadRepository _licenseReadRepository;
        readonly ICurrentUserService _currentUserService;

        public GetAllByCurrentCompanyIdHandler(IGModuleReadRepository gModuleReadRepository, ILicenseReadRepository licenseReadRepository, ICurrentUserService currentUserService)
        {
            _gModuleReadRepository = gModuleReadRepository;
            _licenseReadRepository = licenseReadRepository;
            _currentUserService = currentUserService;
        }

        public async Task<GetAllByCurrentCompanyIdResponse> Handle(GetAllByCurrentCompanyIdRequest request, CancellationToken cancellationToken)
        {
            var currentUser = await _currentUserService.GetCurrentUser();

            var gModules = _gModuleReadRepository.GetAllDeletedStatusDesc(false)
                                               .Select(gm => new GModuleLicenseStatusVM
                                               {
                                                   Id = gm.Id.ToString(),
                                                   CreatedDate = gm.CreatedDate,
                                                   Name = gm.Name,
                                                   LogoPath = gm.LogoPath,
                                                   IsThereLicense = _licenseReadRepository.GetAllDeletedStatusDesc(false, false)
                                                                                          .Where(l => l.GModuleId == gm.Id && l.CompanyId == Guid.Parse(currentUser.MasterCompanyIdFromPlatform) && l.StartDate < DateTime.Today && l.ExpirationDate > DateTime.Today).Count() > 0 ? true : false
                                               }).ToList();
            return new()
            {
                TotalCount = gModules.Count,
                GModules = gModules,
            };
        }
    }
}