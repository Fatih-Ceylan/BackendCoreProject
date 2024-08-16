using Utilities.Core.UtilityDomain.Entities;

namespace BaseProject.Domain.Entities.GCrm.Definitions.ProductManagement.Products
{
    public class ProductBrand : BaseEntity
    {
        public string ProductBrandCode { get; set; }
        public string ProductBrandName { get; set; }
        //public Guid ProductId { get; set; }
        public Product Product { get; set; }
    }
}
