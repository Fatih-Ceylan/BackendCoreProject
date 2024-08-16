using BaseProject.Application.VMs.Definitions.Company;

namespace BaseProject.Application.Features.Queries.Definitions.Company.GetMailCredentialsByCompanies
{
    public class GetMailCredentialsByCompaniesResponse
    {
        public int TotalCount { get; set; }

        public List<CompanyMailCredentialVM> CompanyMailCredentials { get; set; }
    }
}
