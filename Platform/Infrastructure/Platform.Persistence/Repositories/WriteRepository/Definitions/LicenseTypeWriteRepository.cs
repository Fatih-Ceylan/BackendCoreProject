﻿using Platform.Application.Repositories.WriteRepository.Definitions;
using Platform.Domain.Entities.Definitions;
using Platform.Persistence.Contexts;
using Utilities.Infrastructure.UtilityPersistence.Repositories;

namespace Platform.Persistence.Repositories.WriteRepository.Definitions
{
    public class LicenseTypeWriteRepository : WriteRepository<PlatformDbContext, LicenseType>, ILicenseTypeWriteRepository
    {
        public LicenseTypeWriteRepository(PlatformDbContext context) : base(context)
        {

        }
    }
}