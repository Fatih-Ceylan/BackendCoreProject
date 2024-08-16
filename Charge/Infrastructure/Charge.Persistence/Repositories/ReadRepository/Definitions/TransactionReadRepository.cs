using GCharge.Application.Repositories.ReadRepository.Definitions;
using GCharge.Domain.Entities.Definitions;
using GCharge.Persistence.Contexts;

namespace GCharge.Persistence.Repositories.ReadRepository.Definitions
{
    public class TransactionReadRepository : ReadRepository<Transaction>, ITransactionReadRepository
    {
        public TransactionReadRepository(GChargeDbContext context) : base(context)
        {
        }
    }
}
