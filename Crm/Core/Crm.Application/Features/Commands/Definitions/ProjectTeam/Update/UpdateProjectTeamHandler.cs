using AutoMapper;
using GCrm.Application.Repositories.ReadRepository;
using GCrm.Application.Repositories.WriteRepository;
using MediatR;
using Utilities.Core.UtilityApplication.Enums;

namespace GCrm.Application.Features.Commands.Definitions.ProjectTeam.Update
{
    public class UpdateProjectTeamHandler : IRequestHandler<UpdateProjectTeamRequest, UpdateProjectTeamResponse>
    {
        readonly IProjectTeamWriteRepository  _projectTeamWriteRepository;
        readonly IProjectTeamReadRepository  _projectTeamReadRepository;
        readonly IMapper _mapper;

        public UpdateProjectTeamHandler(IProjectTeamWriteRepository projectTeamWriteRepository, IProjectTeamReadRepository projectTeamReadRepository, IMapper mapper)
        {
            _projectTeamWriteRepository = projectTeamWriteRepository;
            _projectTeamReadRepository = projectTeamReadRepository;
            _mapper = mapper;
        }

        public async  Task<UpdateProjectTeamResponse> Handle(UpdateProjectTeamRequest request, CancellationToken cancellationToken)
        {
            var projectteam = await _projectTeamReadRepository.GetByIdAsync(request.Id);
            projectteam = _mapper.Map(request, projectteam);
            await _projectTeamWriteRepository.SaveAsync();

            var updatedResponse = _mapper.Map<UpdateProjectTeamResponse>(projectteam);
            updatedResponse.Message = CommandResponseMessage.UpdatedSuccess.ToString();

            return updatedResponse;
        }
    }
}
