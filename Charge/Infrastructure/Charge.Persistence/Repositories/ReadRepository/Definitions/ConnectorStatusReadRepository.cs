using GCharge.Application.Repositories.ReadRepository.Definitions;
using GCharge.Domain.Entities.Definitions;
using GCharge.Persistence.Contexts;

namespace GCharge.Persistence.Repositories.ReadRepository.Definitions
{
    public class ConnectorStatusReadRepository : ReadRepository<ConnectorStatus>, IConnectorStatusReadRepository
    {
        public ConnectorStatusReadRepository(GChargeDbContext context) : base(context)
        {
        }
    }
}