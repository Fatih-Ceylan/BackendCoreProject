using GCrm.Application.VMs.Definitions;

namespace GCrm.Application.Features.Queries.Definitions.CompanyTender.GetAll
{
    public  class GetAllCompanyTenderResponse
    {
        public int TotalCount { get; set; }
        public List<CompanyTenderVM> CompanyTenders { get; set; }
    }
}
