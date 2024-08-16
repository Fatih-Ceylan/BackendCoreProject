using BaseProject.Domain.Entities.GCrm.Definitions.ProductManagement.Products;
using BaseProject.Persistence.Contexts;
using GCrm.Application.Repositories.WriteRepository;
using Utilities.Infrastructure.UtilityPersistence.Repositories;

namespace GCrm.Persistence.Repositories.WriteRepository
{
    public class ProductBrandWriteRepository : WriteRepository<BaseProjectDbContext, ProductBrand>, IProductBrandWriteRepository
    {
        public ProductBrandWriteRepository(BaseProjectDbContext context) : base(context)
        {
        }
    }
}
