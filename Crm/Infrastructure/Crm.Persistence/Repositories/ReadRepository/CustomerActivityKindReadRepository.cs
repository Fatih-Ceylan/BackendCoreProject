﻿using BaseProject.Domain.Entities.GCrm.Definitions.ActivitiesManagement.Activities;
using BaseProject.Persistence.Contexts;
using GCrm.Application.Repositories.ReadRepository;
using Utilities.Infrastructure.UtilityPersistence.Repositories;

namespace GCrm.Persistence.Repositories.ReadRepository
{
    internal class CustomerActivityKindReadRepository : ReadRepository<BaseProjectDbContext, CustomerActivityKind>, ICustomerActivityKindReadRepository
    {
        public CustomerActivityKindReadRepository(BaseProjectDbContext context) : base(context)
        {
        }
    }
}
