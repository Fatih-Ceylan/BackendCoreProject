﻿using BaseProject.Domain.Entities.GControl.Definitions;
using BaseProject.Persistence.Contexts;
using GControl.Application.Repositories.ReadRepository;
using Utilities.Infrastructure.UtilityPersistence.Repositories;

namespace GControl.Persistence.Repositories.ReadRepository
{
    public class UserMainInfoReadRepository : ReadRepository<BaseProjectDbContext, UserMainInfo>, IUserMainInfoReadRepository
    {
        public UserMainInfoReadRepository(BaseProjectDbContext context) : base(context)
        {
        }
    }
}