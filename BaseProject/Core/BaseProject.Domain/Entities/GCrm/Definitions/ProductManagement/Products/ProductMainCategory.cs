﻿using Utilities.Core.UtilityDomain.Entities;

namespace BaseProject.Domain.Entities.GCrm.Definitions.ProductManagement.Products
{
    public class ProductMainCategory : BaseEntity
    {
        public string Name { get; set; }
        //public Guid ProductId { get; set; }
        public Product Product { get; set; }
    }
}
