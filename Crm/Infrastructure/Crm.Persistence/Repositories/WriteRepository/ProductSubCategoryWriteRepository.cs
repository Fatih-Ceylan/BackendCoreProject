using BaseProject.Domain.Entities.GCrm.Definitions.ProductManagement.Products;
using BaseProject.Persistence.Contexts;
using GCrm.Application.Repositories.WriteRepository;
using Utilities.Infrastructure.UtilityPersistence.Repositories;

namespace GCrm.Persistence.Repositories.WriteRepository
{
    internal class ProductSubCategoryWriteRepository : WriteRepository<BaseProjectDbContext, ProductSubCategory>, IProductSubCategoryWriteRepository
    {
        public ProductSubCategoryWriteRepository(BaseProjectDbContext context) : base(context)
        {
        }
    }
}
