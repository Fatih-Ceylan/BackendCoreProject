using AutoMapper;
using GCrm.Application.Repositories.WriteRepository;
using MediatR;
using Utilities.Core.UtilityApplication.Enums;

namespace GCrm.Application.Features.Commands.Definitions.ProjectManager.Create
{
    public class CreateProjectManagerHandler : IRequestHandler<CreateProjectManagerRequest, CreateProjectManagerResponse>
    {
        readonly IProjectManagerWriteRepository  _projectManagerWriteRepository;
        readonly IMapper _mapper;

        public CreateProjectManagerHandler(IProjectManagerWriteRepository projectManagerWriteRepository, IMapper mapper)
        {
            _projectManagerWriteRepository = projectManagerWriteRepository;
            _mapper = mapper;
        }

        public async  Task<CreateProjectManagerResponse> Handle(CreateProjectManagerRequest request, CancellationToken cancellationToken)
        {
            var projectmanager = _mapper.Map<BaseProject.Domain.Entities.GCrm.Definitions.ProjectManagement.Projects.ProjectManager>(request);

            projectmanager = await _projectManagerWriteRepository.AddAsync(projectmanager);
            await _projectManagerWriteRepository.SaveAsync();

            var createdResponse = _mapper.Map<CreateProjectManagerResponse>(projectmanager);
            createdResponse.Message = CommandResponseMessage.AddedSuccess.ToString();

            return createdResponse;
        }
    }
}
