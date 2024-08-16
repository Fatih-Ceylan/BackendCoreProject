using GCrm.Application.VMs.Definitions;

namespace GCrm.Application.Features.Queries.Definitions.Product.GetAll
{
    public class GetAllProductResponse
    {
        public int TotalCount { get; set; }

        public List<ProductVM>  Products { get; set; }
    }
}
