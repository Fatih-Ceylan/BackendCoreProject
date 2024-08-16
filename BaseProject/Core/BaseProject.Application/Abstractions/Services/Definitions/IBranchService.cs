using BaseProject.Application.DTOs.Definitions.Branch;

namespace BaseProject.Application.Abstractions.Services.Definitions
{
    public interface IBranchService
    {
        Task<List<BranchDTO>> GetAllActiveBranches();
        Task<List<BranchDTO>> GetAllActiveBranchesWithIds(string companyId, string branchId);
        Task<BranchDTO> GetAllActiveBranchWithIds(string companyId, string branchId);
    }
}
