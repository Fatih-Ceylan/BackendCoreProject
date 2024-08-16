using Utilities.Core.UtilityDomain.Entities;

namespace BaseProject.Domain.Entities.GCrm.Definitions.ProductManagement.Products
{
    public class ProductManufacturer : BaseEntity
    {
        public string ProductManufacturerCode { get; set; }
        public string ProductManufacturerName { get; set; }
        //public Guid ProductId { get; set; }
        public Product Product { get; set; }
    }
}
