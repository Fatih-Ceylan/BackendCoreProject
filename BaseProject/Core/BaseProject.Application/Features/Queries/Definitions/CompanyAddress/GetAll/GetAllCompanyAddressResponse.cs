using BaseProject.Application.VMs.Definitions.CompanyAddress;

namespace BaseProject.Application.Features.Queries.Definitions.CompanyAddress.GetAll
{
    public class GetAllCompanyAddressResponse
    {
        public int TotalCount { get; set; }

        public List<CompanyAddressVM> CompanyAddresses { get; set; }
    }
}