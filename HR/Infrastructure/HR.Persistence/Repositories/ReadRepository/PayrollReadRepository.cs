using BaseProject.Domain.Entities.HR.Employment;
using BaseProject.Persistence.Contexts;
using HR.Application.Repositories.ReadRepository;
using Utilities.Infrastructure.UtilityPersistence.Repositories;

namespace HR.Persistence.Repositories.ReadRepository
{
    public class PayrollReadRepository : ReadRepository<BaseProjectDbContext, Payroll>, IPayrollReadRepository
    {
        public PayrollReadRepository(BaseProjectDbContext context) : base(context)
        {
        }
    }
}
