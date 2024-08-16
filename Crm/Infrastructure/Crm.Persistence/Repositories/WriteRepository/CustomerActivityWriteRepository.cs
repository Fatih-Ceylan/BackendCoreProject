using BaseProject.Domain.Entities.GCrm.Definitions.ActivitiesManagement.Activities;
using BaseProject.Persistence.Contexts;
using GCrm.Application.Repositories.WriteRepository;
using Utilities.Infrastructure.UtilityPersistence.Repositories;

namespace GCrm.Persistence.Repositories.WriteRepository
{
    internal class CustomerActivityWriteRepository : WriteRepository<BaseProjectDbContext, CustomerActivity>, ICustomerActivityWriteRepository
    {
        public CustomerActivityWriteRepository(BaseProjectDbContext context) : base(context)
        {
        }
    }
}
