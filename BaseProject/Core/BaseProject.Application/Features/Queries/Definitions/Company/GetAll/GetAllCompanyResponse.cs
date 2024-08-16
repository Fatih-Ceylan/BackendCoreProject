using BaseProject.Application.VMs.Definitions.Company;

namespace BaseProject.Application.Features.Queries.Definitions.Company.GetAll
{
    public class GetAllCompanyResponse
    {
        public int TotalCount { get; set; }

        public List<CompanyVM> Companies { get; set; }
    }
}