using GCrm.Application.VMs.Definitions;

namespace GCrm.Application.Features.Queries.Definitions.ProductSubCategory.GetAll
{
    public  class GetAllProductSubCategoryResponse
    {
        public int TotalCount { get; set; }

        public List<ProductSubCategoryVM>  productSubCategories { get; set; }
    }
}
