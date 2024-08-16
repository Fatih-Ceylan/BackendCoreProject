using AutoMapper;
using GCrm.Application.Repositories.ReadRepository;
using GCrm.Application.Repositories.WriteRepository;
using MediatR;
using Utilities.Core.UtilityApplication.Enums;

namespace GCrm.Application.Features.Commands.Definitions.ProjectStatues.Update
{
    public class UpdateProjectStatuesHandler : IRequestHandler<UpdateProjectStatuesRequest, UpdateProjectStatuesResponse>
    {
        readonly IProjectStatuesReadRepository _projectStatuesReadRepository;
        readonly IProjectStatuesWriteRepository _projectStatuesWriteRepository;
        readonly IMapper _mapper;
        public UpdateProjectStatuesHandler(IProjectStatuesReadRepository projectStatuesReadRepository, IProjectStatuesWriteRepository projectStatuesWriteRepository, IMapper mapper)
        {
            _projectStatuesReadRepository = projectStatuesReadRepository;
            _projectStatuesWriteRepository = projectStatuesWriteRepository;
            _mapper = mapper;
        }

        public async  Task<UpdateProjectStatuesResponse> Handle(UpdateProjectStatuesRequest request, CancellationToken cancellationToken)
        {
            var projectstatues = await _projectStatuesReadRepository.GetByIdAsync(request.Id);
            projectstatues = _mapper.Map(request, projectstatues);
            await _projectStatuesWriteRepository.SaveAsync();

            var updatedResponse = _mapper.Map<UpdateProjectStatuesResponse>(projectstatues);
            updatedResponse.Message = CommandResponseMessage.UpdatedSuccess.ToString();

            return updatedResponse;
        }
    }
}
