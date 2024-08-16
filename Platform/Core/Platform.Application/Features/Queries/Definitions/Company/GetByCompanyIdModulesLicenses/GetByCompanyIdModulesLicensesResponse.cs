using Platform.Application.VMs.Definitions.GModule;

namespace Platform.Application.Features.Queries.Definitions.Company.GetByCompanyIdModulesLicenses
{
    public class GetByCompanyIdModulesLicensesResponse
    {
        public List<LicenseOfTheCompanysModuleVM> LicenseOfTheCompanysModules { get; set; }
    }
}