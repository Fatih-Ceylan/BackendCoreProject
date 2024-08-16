using AutoMapper;
using BaseProject.Application.Repositories.WriteRepository.Definitions;
using MediatR;
using Utilities.Core.UtilityApplication.Enums;
using T = BaseProject.Domain.Entities.Definitions;

namespace BaseProject.Application.Features.Commands.Definitions.Branch.Create
{
    public class CreateBranchHandler : IRequestHandler<CreateBranchRequest, CreateBranchResponse>
    {
        readonly IBranchWriteRepository _branchWriteRepository;
        readonly IMapper _mapper;

        public CreateBranchHandler(IBranchWriteRepository branchWriteRepository, IMapper mapper)
        {
            _branchWriteRepository = branchWriteRepository;
            _mapper = mapper;
        }

        public async Task<CreateBranchResponse> Handle(CreateBranchRequest request, CancellationToken cancellationToken)
        {
            T.Branch branch = _mapper.Map<T.Branch>(request);

            branch = await _branchWriteRepository.AddAsync(branch);
            await _branchWriteRepository.SaveAsync();

            var createdResponse = _mapper.Map<CreateBranchResponse>(branch);
            createdResponse.Message = CommandResponseMessage.AddedSuccess.ToString();

            return createdResponse;
        }
    }
}