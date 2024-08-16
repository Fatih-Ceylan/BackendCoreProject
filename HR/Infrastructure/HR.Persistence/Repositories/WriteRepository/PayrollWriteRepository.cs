using BaseProject.Domain.Entities.HR.Employment;
using BaseProject.Persistence.Contexts;
using HR.Application.Repositories.WriteRepository;
using Utilities.Infrastructure.UtilityPersistence.Repositories;

namespace HR.Persistence.Repositories.WriteRepository
{
    public class PayrollWriteRepository : WriteRepository<BaseProjectDbContext, Payroll>, IPayrollWriteRepository
    {
        public PayrollWriteRepository(BaseProjectDbContext context) : base(context)
        {
        }
    }
}
