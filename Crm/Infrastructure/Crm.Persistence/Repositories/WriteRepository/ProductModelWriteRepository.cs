using BaseProject.Domain.Entities.GCrm.Definitions.ProductManagement.Products;
using BaseProject.Persistence.Contexts;
using GCrm.Application.Repositories.WriteRepository;
using Utilities.Infrastructure.UtilityPersistence.Repositories;

namespace GCrm.Persistence.Repositories.WriteRepository
{
    internal class ProductModelWriteRepository : WriteRepository<BaseProjectDbContext, ProductModel>, IProductModelWriteRepository
    {
        public ProductModelWriteRepository(BaseProjectDbContext context) : base(context)
        {
        }
    }
}
