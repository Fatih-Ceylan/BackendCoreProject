using BaseProject.Domain.Entities.NLLogistics.Definitions;
using BaseProject.Persistence.Contexts;
using NLLogistics.Application.Repositories.WriteRepositories.Definitions;
using Utilities.Infrastructure.UtilityPersistence.Repositories;

namespace NLLogistics.Persistence.Repositories.WriteRepositories.Definitions
{
    public class VesselWriteRepository: WriteRepository<BaseProjectDbContext, Vessel>, IVesselWriteRepository
    {
        public VesselWriteRepository(BaseProjectDbContext context) : base(context)
        {

        }
    }
}