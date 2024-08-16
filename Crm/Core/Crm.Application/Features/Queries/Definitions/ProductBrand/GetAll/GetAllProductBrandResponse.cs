using GCrm.Application.VMs.Definitions;

namespace GCrm.Application.Features.Queries.Definitions.ProductBrand.GetAll
{
    public  class GetAllProductBrandResponse
    {
        public int TotalCount { get; set; }

        public List<ProductBrandVM>  ProductBrands { get; set; }
    }
}
