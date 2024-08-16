using GCrm.Application.VMs.Definitions;

namespace GCrm.Application.Features.Queries.Definitions.ProductMainCategory.GetAll
{
    public  class GetAllProductMainCategoryResponse
    {
        public int TotalCount { get; set; }

        public List<ProductMainCategoryVM>  productMainCategories { get; set; }
    }
}
