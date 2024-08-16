using GCrm.Application.VMs.Definitions;

namespace GCrm.Application.Features.Queries.Definitions.CustomerProject.GetAll
{
    public  class GetAllCustomerProjectResponse
    {
        public int TotalCount { get; set; }
        public List<CustomerProjectVM> customerProjectVM { get; set; }
    }
}
