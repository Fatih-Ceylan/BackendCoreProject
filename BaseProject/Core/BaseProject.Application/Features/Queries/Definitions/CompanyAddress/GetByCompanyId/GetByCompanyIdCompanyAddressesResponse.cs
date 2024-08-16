using BaseProject.Application.VMs.Definitions.CompanyAddress;

namespace BaseProject.Application.Features.Queries.Definitions.CompanyAddress.GetByCompanyId
{
    public class GetByCompanyIdCompanyAddressesResponse
    {
        public List<CompanyAddressVM> CompanyAddresses { get; set; }
    }
}