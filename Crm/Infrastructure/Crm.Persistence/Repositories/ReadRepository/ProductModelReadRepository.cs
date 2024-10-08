﻿using BaseProject.Domain.Entities.GCrm.Definitions.ProductManagement.Products;
using BaseProject.Persistence.Contexts;
using GCrm.Application.Repositories.ReadRepository;
using Utilities.Infrastructure.UtilityPersistence.Repositories;

namespace GCrm.Persistence.Repositories.ReadRepository
{
    public  class ProductModelReadRepository : ReadRepository<BaseProjectDbContext, ProductModel>, IProductModelReadRepository
    {
        public ProductModelReadRepository(BaseProjectDbContext context) : base(context)
        {
        }
    }
}
