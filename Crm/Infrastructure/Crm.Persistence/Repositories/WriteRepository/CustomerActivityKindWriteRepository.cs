using BaseProject.Domain.Entities.GCrm.Definitions.ActivitiesManagement.Activities;
using BaseProject.Persistence.Contexts;
using GCrm.Application.Repositories.WriteRepository;
using Utilities.Infrastructure.UtilityPersistence.Repositories;

namespace GCrm.Persistence.Repositories.WriteRepository
{
    internal class CustomerActivityKindWriteRepository : WriteRepository<BaseProjectDbContext, CustomerActivityKind>, ICustomerActivityKindWriteRepository
    {
        public CustomerActivityKindWriteRepository(BaseProjectDbContext context) : base(context)
        {
        }
    }
}
