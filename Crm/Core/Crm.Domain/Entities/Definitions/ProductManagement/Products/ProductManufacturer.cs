using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utilities.Core.UtilityDomain.Entities;

namespace GCrm.Domain.Entities.Definitions.ProductManagement.Products
{
    public  class ProductManufacturer : BaseEntity
    {
        public string ProductManufacturerCode { get; set; }
        public string ProductManufacturerName { get; set; }
        public Guid ProductId { get; set; }
        public Product Product { get; set; }
    }
}
