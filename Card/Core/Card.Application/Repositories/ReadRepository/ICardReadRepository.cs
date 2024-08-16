using T = BaseProject.Domain.Entities.Card.Definitions;
using Utilities.Core.UtilityApplication.Interfaces;

namespace Card.Application.Repositories.ReadRepository
{
    public interface ICardReadRepository : IReadRepository<T.Card>
    {
    }
}
