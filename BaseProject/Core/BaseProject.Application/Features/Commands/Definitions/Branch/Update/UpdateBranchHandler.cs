using AutoMapper;
using BaseProject.Application.Repositories.ReadRepository.Definitions;
using BaseProject.Application.Repositories.WriteRepository.Definitions;
using MediatR;
using Utilities.Core.UtilityApplication.Enums;
using T = BaseProject.Domain.Entities.Definitions;

namespace BaseProject.Application.Features.Commands.Definitions.Branch.Update
{
    public class UpdateBranchHandler : IRequestHandler<UpdateBranchRequest, UpdateBranchResponse>
    {
        readonly IBranchReadRepository _branchReadRepository;
        readonly IBranchWriteRepository _branchWriteRepository;
        readonly IMapper _mapper;

        public UpdateBranchHandler(IBranchReadRepository branchReadRepository, IBranchWriteRepository branchWriteRepository, IMapper mapper)
        {
            _branchReadRepository = branchReadRepository;
            _branchWriteRepository = branchWriteRepository;
            _mapper = mapper;
        }

        public async Task<UpdateBranchResponse> Handle(UpdateBranchRequest request, CancellationToken cancellationToken)
        {
            T.Branch branch = await _branchReadRepository.GetByIdAsync(request.Id);
            branch = _mapper.Map(request, branch);

            await _branchWriteRepository.SaveAsync();

            var updatedResponse = _mapper.Map<UpdateBranchResponse>(branch);
            updatedResponse.Message = CommandResponseMessage.UpdatedSuccess.ToString();

            return updatedResponse;
        }
    }
}