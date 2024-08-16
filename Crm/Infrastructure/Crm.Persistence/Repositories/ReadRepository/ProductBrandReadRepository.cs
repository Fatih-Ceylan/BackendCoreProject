using BaseProject.Domain.Entities.GCrm.Definitions.ProductManagement.Products;
using BaseProject.Persistence.Contexts;
using GCrm.Application.Repositories.ReadRepository;
using Utilities.Infrastructure.UtilityPersistence.Repositories;

namespace GCrm.Persistence.Repositories.ReadRepository
{
    public  class ProductBrandReadRepository : ReadRepository<BaseProjectDbContext, ProductBrand>, IProductBrandReadRepository
    {
        public ProductBrandReadRepository(BaseProjectDbContext context) : base(context)
        {
        }
    }
}
