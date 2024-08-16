using BaseProject.Domain.Entities.Card.Definitions;
using BaseProject.Persistence.Contexts;
using Card.Application.Repositories.WriteRepository;
using T = Utilities.Infrastructure.UtilityPersistence.Repositories;

namespace Card.Persistence.Repositories.WriteRepository
{
    public class PhoneNumberWriteRepository : T.WriteRepository<BaseProjectDbContext, PhoneNumber>, IPhoneNumberWriteRepository
    {
        public PhoneNumberWriteRepository(BaseProjectDbContext context) : base(context)
        {

        }
    }
}
