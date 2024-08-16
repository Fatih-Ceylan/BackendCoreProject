using GCrm.Application.VMs.Definitions;

namespace GCrm.Application.Features.Queries.Definitions.ProductType.GetAll
{
    public  class GetAllProductTypeResponse
    {
        public int TotalCount { get; set; }

        public List<ProductTypeVM>  productTypes { get; set; }
    }
}
