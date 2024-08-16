using BaseProject.Domain.Entities.GCrm.Definitions.ProductManagement.Products;
using BaseProject.Persistence.Contexts;
using GCrm.Application.Repositories.WriteRepository;
using Utilities.Infrastructure.UtilityPersistence.Repositories;

namespace GCrm.Persistence.Repositories.WriteRepository
{
    internal class ProductManufacturerWriteRepository : WriteRepository<BaseProjectDbContext, ProductManufacturer>, IProductManufacturerWriteRepository
    {
        public ProductManufacturerWriteRepository(BaseProjectDbContext context) : base(context)
        {
        }
    }
}
