using BaseProject.Domain.Entities.GCrm.Definitions.ProductManagement.Products;
using BaseProject.Persistence.Contexts;
using GCrm.Application.Repositories.WriteRepository;
using Utilities.Infrastructure.UtilityPersistence.Repositories;

namespace GCrm.Persistence.Repositories.WriteRepository
{
    internal class ProductWriteRepository : WriteRepository<BaseProjectDbContext, Product>, IProductWriteRepository
    {
        public ProductWriteRepository(BaseProjectDbContext context) : base(context)
        {
        }
    }
}
