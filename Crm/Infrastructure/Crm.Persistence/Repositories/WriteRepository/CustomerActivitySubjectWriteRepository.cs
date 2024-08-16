using BaseProject.Domain.Entities.GCrm.Definitions.ActivitiesManagement.Activities;
using BaseProject.Persistence.Contexts;
using GCrm.Application.Repositories.WriteRepository;
using Utilities.Infrastructure.UtilityPersistence.Repositories;

namespace GCrm.Persistence.Repositories.WriteRepository
{
    public  class CustomerActivitySubjectWriteRepository : WriteRepository<BaseProjectDbContext, CustomerActivitySubject>, ICustomerActivitySubjectWriteRepository
    {
        public CustomerActivitySubjectWriteRepository(BaseProjectDbContext context) : base(context)
        {
        }
    }
}
