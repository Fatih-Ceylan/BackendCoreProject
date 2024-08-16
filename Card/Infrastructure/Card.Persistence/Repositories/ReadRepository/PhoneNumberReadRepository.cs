using BaseProject.Domain.Entities.Card.Definitions;
using BaseProject.Persistence.Contexts;
using Card.Application.Repositories.ReadRepository;
using Utilities.Infrastructure.UtilityPersistence.Repositories;

namespace Card.Persistence.Repositories.ReadRepository
{
    public class PhoneNumberReadRepository : ReadRepository<BaseProjectDbContext, PhoneNumber>, IPhoneNumberReadRepository
    {
        public PhoneNumberReadRepository(BaseProjectDbContext context) : base(context)
        {

        }
    }
}
