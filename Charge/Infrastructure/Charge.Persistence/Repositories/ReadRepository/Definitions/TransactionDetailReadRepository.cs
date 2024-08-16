using GCharge.Application.Repositories.ReadRepository.Definitions;
using GCharge.Domain.Entities.Definitions;
using GCharge.Persistence.Contexts;

namespace GCharge.Persistence.Repositories.ReadRepository.Definitions
{
    public class TransactionDetailReadRepository : ReadRepository<TransactionDetail>, ITransactionDetailReadRepository
    {
        public TransactionDetailReadRepository(GChargeDbContext context) : base(context)
        {
        }
    }
}
