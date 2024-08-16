using BaseProject.Domain.Entities.GCrm.Definitions.ProductManagement.Products;
using BaseProject.Persistence.Contexts;
using GCrm.Application.Repositories.WriteRepository;
using Utilities.Infrastructure.UtilityPersistence.Repositories;

namespace GCrm.Persistence.Repositories.WriteRepository
{
    internal class ProductMainCategoryWriteRepository : WriteRepository<BaseProjectDbContext, ProductMainCategory>, IProductMainCategoryWriteRepository
    {
        public ProductMainCategoryWriteRepository(BaseProjectDbContext context) : base(context)
        {
        }
    }
}
