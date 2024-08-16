using GCrm.Application.VMs.Definitions;

namespace GCrm.Application.Features.Queries.Definitions.ProductModel.GetAll
{
    public  class GetAllProductModelResponse
    {
        public int TotalCount { get; set; }

        public List<ProductModelVM>  productModels { get; set; }
    }
}
