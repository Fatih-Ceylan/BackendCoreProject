using Utilities.Core.UtilityDomain.Entities;

namespace BaseProject.Domain.Entities.GCrm.Definitions.ProductManagement.Products
{
    public class ProductModel : BaseEntity
    {
        public string ProductModelCode { get; set; }
        public string ProductModelName { get; set; }
        //public Guid ProductId { get; set; }
        public Product Product { get; set; }
    }
}
