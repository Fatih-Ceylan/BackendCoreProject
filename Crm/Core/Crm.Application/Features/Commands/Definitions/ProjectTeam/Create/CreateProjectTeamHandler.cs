using AutoMapper;
using GCrm.Application.Repositories.WriteRepository;
using MediatR;
using Utilities.Core.UtilityApplication.Enums;
using T = BaseProject.Domain.Entities.GCrm.Definitions.ProjectManagement.Projects;


namespace GCrm.Application.Features.Commands.Definitions.ProjectTeam.Create
{
    public class CreateProjectTeamHandler : IRequestHandler<CreateProjectTeamRequest, CreateProjectTeamResponse>
    {
        readonly IProjectTeamWriteRepository  _projectTeamWriteRepository;
        readonly IMapper _mapper;

        public CreateProjectTeamHandler(IProjectTeamWriteRepository projectTeamWriteRepository, IMapper mapper)
        {
            _projectTeamWriteRepository = projectTeamWriteRepository;
            _mapper = mapper;
        }

        public async  Task<CreateProjectTeamResponse> Handle(CreateProjectTeamRequest request, CancellationToken cancellationToken)
        {
            var projectteam = _mapper.Map<T.ProjectTeam>(request);

            projectteam = await _projectTeamWriteRepository.AddAsync(projectteam);
            await _projectTeamWriteRepository.SaveAsync();

            var createdResponse = _mapper.Map<CreateProjectTeamResponse>(projectteam);
            createdResponse.Message = CommandResponseMessage.AddedSuccess.ToString();

            return createdResponse;
        }
    }
}
