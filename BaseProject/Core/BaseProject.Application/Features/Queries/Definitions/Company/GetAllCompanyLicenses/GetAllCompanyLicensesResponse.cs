using BaseProject.Application.VMs.Definitions.CompanyLicense;

namespace BaseProject.Application.Features.Queries.Definitions.Company.GetAllCompanyLicenses
{
    public class GetAllCompanyLicensesResponse
    {
        public int TotalCount { get; set; }

        public List<CompanyLicenseCreateVM> CompanyLicenses { get; set; }
    }
}