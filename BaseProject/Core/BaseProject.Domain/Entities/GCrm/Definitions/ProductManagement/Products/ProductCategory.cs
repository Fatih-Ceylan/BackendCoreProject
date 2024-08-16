using Utilities.Core.UtilityDomain.Entities;

namespace BaseProject.Domain.Entities.GCrm.Definitions.ProductManagement.Products
{
    public class ProductCategory : BaseEntity
    {
        public string ProductCategoryCode { get; set; }
        public string ProductCategoryName { get; set; }
        public string CategoryTopCode { get; set; }
        public string CategoryTopCodeName { get; set; }
        //public Guid ProductId { get; set; }
        public Product Product { get; set; }
    }
}
