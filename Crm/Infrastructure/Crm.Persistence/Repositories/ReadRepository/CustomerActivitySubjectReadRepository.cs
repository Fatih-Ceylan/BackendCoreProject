using BaseProject.Domain.Entities.GCrm.Definitions.ActivitiesManagement.Activities;
using BaseProject.Persistence.Contexts;
using GCrm.Application.Repositories.ReadRepository;
using Utilities.Infrastructure.UtilityPersistence.Repositories;

namespace GCrm.Persistence.Repositories.ReadRepository
{
    public  class CustomerActivitySubjectReadRepository : ReadRepository<BaseProjectDbContext, CustomerActivitySubject>, ICustomerActivitySubjectReadRepository
    {
        public CustomerActivitySubjectReadRepository(BaseProjectDbContext context) : base(context)
        {
        }
    }
}
