using GCrm.Application.VMs.Definitions;

namespace GCrm.Application.Features.Queries.Definitions.CompanyContactName.GetAll
{
    public  class GetAllCompanyContactNameResponse
    {
        public int TotalCount { get; set; }
        public List<CompanyContactNameVM>  CompanyContactNames { get; set; }
    }
}
