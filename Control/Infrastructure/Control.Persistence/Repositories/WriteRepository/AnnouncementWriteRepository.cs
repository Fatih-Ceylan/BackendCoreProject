﻿using BaseProject.Domain.Entities.GControl.Definitions;
using BaseProject.Persistence.Contexts;
using GControl.Application.Repositories.WriteRepository;
using T = Utilities.Infrastructure.UtilityPersistence.Repositories;

namespace GControl.Persistence.Repositories.WriteRepository
{
    public class AnnouncementWriteRepository : T.WriteRepository<BaseProjectDbContext, Announcement>, IAnnouncementWriteRepository
    {
        public AnnouncementWriteRepository(BaseProjectDbContext context) : base(context)
        {
        }
    }
}
