using Platform.Application.VMs.Definitions.Company;

namespace Platform.Application.Features.Queries.Definitions.Company.GetAll
{
    public class GetAllCompanyResponse
    {
        public int TotalCount { get; set; }

        public List<CompanyVM> Companies { get; set; }
    }
}
