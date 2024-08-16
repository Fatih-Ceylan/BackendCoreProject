﻿using T=BaseProject.Domain.Entities.Card.Definitions;
using Utilities.Core.UtilityApplication.Interfaces;

namespace Card.Application.Repositories.WriteRepository
{
    public interface ICardWriteRepository : IWriteRepository<T.Card>
    {
    }
}