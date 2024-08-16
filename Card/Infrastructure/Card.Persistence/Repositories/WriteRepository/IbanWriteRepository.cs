using BaseProject.Domain.Entities.Card.Definitions;
using BaseProject.Persistence.Contexts;
using Card.Application.Repositories.WriteRepository;
using T = Utilities.Infrastructure.UtilityPersistence.Repositories;

namespace Card.Persistence.Repositories.WriteRepository
{
    public class IbanWriteRepository : T.WriteRepository<BaseProjectDbContext, Iban>, IIbanWriteRepository
    {
        public IbanWriteRepository(BaseProjectDbContext context) : base(context)
        {

        }
    }
}
