using BaseProject.Domain.Entities.GCrm.Definitions.ProductManagement.Products;
using BaseProject.Persistence.Contexts;
using GCrm.Application.Repositories.ReadRepository;
using Utilities.Infrastructure.UtilityPersistence.Repositories;

namespace GCrm.Persistence.Repositories.ReadRepository
{
    public  class ProductManufacturerReadRepository : ReadRepository<BaseProjectDbContext, ProductManufacturer>, IProductManufacturerReadRepository
    {
        public ProductManufacturerReadRepository(BaseProjectDbContext context) : base(context)
        {
        }
    }
}
