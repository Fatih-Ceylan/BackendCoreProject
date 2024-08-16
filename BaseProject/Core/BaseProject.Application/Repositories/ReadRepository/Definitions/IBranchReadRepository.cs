using BaseProject.Domain.Entities.Definitions;
using Utilities.Core.UtilityApplication.Interfaces;

namespace BaseProject.Application.Repositories.ReadRepository.Definitions
{
    public interface IBranchReadRepository : IReadRepository<Branch>
    {
        IQueryable<Branch> FilteredBranch(string filterText, string propertyName);
    }
}
