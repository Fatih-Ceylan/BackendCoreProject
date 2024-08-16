using GCrm.Application.VMs.Definitions;

namespace GCrm.Application.Features.Queries.Definitions.ProductManufacturer.GetAll
{
    public  class GetAllProductManufacturerResponse
    {
        public int TotalCount { get; set; }

        public List<ProductManufacturerVM>  productManufacturers { get; set; }
    }
}
