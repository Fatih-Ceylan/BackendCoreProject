using GCrm.Application.VMs.Definitions;

namespace GCrm.Application.Features.Queries.Definitions.CustomerActivitySubject.GetAll
{
    public  class GetAllCustomerActivitySubjectResponse
    {
        public int TotalCount { get; set; }

        public List<CustomerActivitySubjectVM>  CustomerActivitySubjects { get; set; }
    }
}
