using GCrm.Application.VMs.Definitions;

namespace GCrm.Application.Features.Queries.Definitions.ProductCategory.GetAll
{
    public  class GetAllProductCategoryResponse
    {
        public int TotalCount { get; set; }

        public List<ProductCategoryVM> productCategories  { get; set; }
    }
}
