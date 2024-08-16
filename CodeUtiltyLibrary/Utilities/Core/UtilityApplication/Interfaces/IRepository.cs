using Microsoft.EntityFrameworkCore;
using Utilities.Core.UtilityDomain.Entities;

namespace Utilities.Core.UtilityApplication.Interfaces
{
    public interface IRepository<T> where T : BaseEntity
    {
        DbSet<T> Table { get; }
    }
}
