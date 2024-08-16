using GCrm.Application.VMs.Definitions;

namespace GCrm.Application.Features.Queries.Definitions.CustomerSector.GetAll
{
    public class GetAllCustomerSectorResponse
    {
        public int TotalCount { get; set; }

        public List<CustomerSectorVM> CustomerSectors { get; set; }

    }
}
