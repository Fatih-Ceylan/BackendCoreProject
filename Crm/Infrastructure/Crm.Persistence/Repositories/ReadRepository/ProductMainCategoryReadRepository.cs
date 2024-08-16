using BaseProject.Domain.Entities.GCrm.Definitions.ProductManagement.Products;
using BaseProject.Persistence.Contexts;
using GCrm.Application.Repositories.ReadRepository;
using Utilities.Infrastructure.UtilityPersistence.Repositories;

namespace GCrm.Persistence.Repositories.ReadRepository
{
    public  class ProductMainCategoryReadRepository : ReadRepository<BaseProjectDbContext, ProductMainCategory>, IProductMainCategoryReadRepository
    {
        public ProductMainCategoryReadRepository(BaseProjectDbContext context) : base(context)
        {
        }
    }
}
