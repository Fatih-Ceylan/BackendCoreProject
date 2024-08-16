using BaseProject.Application.DTOs.Platform.Definitions.License;
using BaseProject.Application.Repositories.ReadRepository.Definitions;
using BaseProject.Application.VMs.Platform.Definitions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Platform.Application.Repositories.ReadRepository.Definitions;
using Utilities.Core.UtilityApplication.Abstractions.Services.CurrentUser;

namespace BaseProject.Api.Controllers.Definitions
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(AuthenticationSchemes = "Admin")]
    public class CompanyLicenseController : ControllerBase
    {
        readonly ILicenseReadRepository _licenseReadRepository;
        readonly ICompanyLicenseReadRepository _companyLicenseReadRepository;
        readonly ICurrentUserService _currentUserService;

        public CompanyLicenseController(ILicenseReadRepository licenseReadRepository, ICompanyLicenseReadRepository companyLicenseReadRepository, ICurrentUserService currentUserService)
        {
            _licenseReadRepository = licenseReadRepository;
            _companyLicenseReadRepository = companyLicenseReadRepository;
            _currentUserService = currentUserService;
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> GetCompanyLicenses()
        {
            var currentUser = await _currentUserService.GetCurrentUser();

            var licenses = _licenseReadRepository.GetAllDeletedStatusDesc(false)
                                                        .Where(l => l.CompanyId == Guid.Parse(currentUser.MasterCompanyIdFromPlatform) && l.StartDate < DateTime.Today && l.ExpirationDate > DateTime.Today)
                                                        .Select(l => new LicenseVM
                                                        {
                                                            Id = l.Id.ToString(),
                                                            CreatedDate = l.CreatedDate,
                                                            GModuleId = l.GModuleId.ToString(),
                                                            GModuleName = l.GModule.Name,
                                                            LicenseTypeId = l.LicenseTypeId.ToString(),
                                                            LicenseTypeName = l.LicenseType.Name,
                                                            LicenseKey = l.LicenseKey.ToString(),
                                                            StartDate = l.StartDate,
                                                            ExpirationDate = l.ExpirationDate,
                                                            RemainingUsageDays = (l.ExpirationDate - DateTime.Today).Days < 0 ? 0 : (l.ExpirationDate - DateTime.Today).Days,
                                                            TotalCompanyNumber = l.TotalCompanyNumber,
                                                            TotalUserNumber = l.TotalUserNumber,
                                                        }).ToList();

            var companyLicenses = _companyLicenseReadRepository.GetAllDeletedStatus(false).Where(cl => cl.IsInUse == true).ToList();

            var result = (from l in licenses
                          select new LicenseVM
                          {
                              Id = l.Id,
                              CreatedDate = l.CreatedDate,
                              GModuleId = l.GModuleId,
                              GModuleName = l.GModuleName,
                              LicenseTypeId = l.LicenseTypeId,
                              LicenseTypeName = l.LicenseTypeName,
                              LicenseKey = l.LicenseKey,
                              StartDate = l.StartDate,
                              ExpirationDate = l.ExpirationDate,
                              RemainingUsageDays = (l.ExpirationDate - DateTime.Today).Days < 0 ? 0 : (l.ExpirationDate - DateTime.Today).Days,
                              TotalCompanyNumber = l.TotalCompanyNumber,
                              TotalUserNumber = l.TotalUserNumber,
                              UsingStatus = companyLicenses.Where(cl => cl.LicenseId == Guid.Parse(l.Id)).Count() > 0 ? true : false,
                              Using = companyLicenses.Where(cl => cl.LicenseId == Guid.Parse(l.Id)).Count(),
                              CanUse = l.TotalCompanyNumber - companyLicenses.Where(cl => cl.LicenseId == Guid.Parse(l.Id)).Count(),
                          }).ToList();

            GetAllLicensesResponseDto licensesDto = new();
            licensesDto.TotalCount = result.Count;
            licensesDto.Licenses = result;

            return Ok(licensesDto);
        }
    }
}