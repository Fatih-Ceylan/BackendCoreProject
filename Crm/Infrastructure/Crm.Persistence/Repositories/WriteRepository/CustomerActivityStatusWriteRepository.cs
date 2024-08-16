﻿using BaseProject.Domain.Entities.GCrm.Definitions.ActivitiesManagement.Activities;
using BaseProject.Persistence.Contexts;
using GCrm.Application.Repositories.WriteRepository;
using Utilities.Infrastructure.UtilityPersistence.Repositories;

namespace GCrm.Persistence.Repositories.WriteRepository
{
    public  class CustomerActivityStatusWriteRepository : WriteRepository<BaseProjectDbContext, CustomerActivityStatus>, ICustomerActivityStatusWriteRepository
    {
        public CustomerActivityStatusWriteRepository(BaseProjectDbContext context) : base(context)
        {
        }
    }
}
