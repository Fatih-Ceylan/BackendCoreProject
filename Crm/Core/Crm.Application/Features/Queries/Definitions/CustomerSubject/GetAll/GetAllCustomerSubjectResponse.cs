using GCrm.Application.VMs.Definitions;

namespace GCrm.Application.Features.Queries.Definitions.CustomerSubject.GetAll
{
    public  class GetAllCustomerSubjectResponse
    {
        public int TotalCount { get; set; }

        public List<CustomerSubjectVM> customerSubjectVMs { get; set; }
    }
}
