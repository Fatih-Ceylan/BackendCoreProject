using BaseProject.Application.Repositories.WriteRepository.Definitions;
using MediatR;
using Utilities.Core.UtilityApplication.Enums;

namespace BaseProject.Application.Features.Commands.Definitions.Branch.Delete
{
    public class BranchDeleteHandler : IRequestHandler<DeleteBranchRequest, DeleteBranchResponse>
    {
        readonly IBranchWriteRepository _branchWriteRepository;

        public BranchDeleteHandler(IBranchWriteRepository branchWriteRepository)
        {
            _branchWriteRepository = branchWriteRepository;
        }

        public async Task<DeleteBranchResponse> Handle(DeleteBranchRequest request, CancellationToken cancellationToken)
        {
            await _branchWriteRepository.SoftDeleteAsync(request.Id);
            await _branchWriteRepository.SaveAsync();

            return new()
            {
                Message = CommandResponseMessage.DeletedSuccess.ToString()
            };
        }
    }
}