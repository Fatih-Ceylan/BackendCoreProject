using AutoMapper;
using GCrm.Application.Repositories.WriteRepository;
using MediatR;
using Utilities.Core.UtilityApplication.Enums;
using T = BaseProject.Domain.Entities.GCrm.Definitions.ProjectManagement.Projects;


namespace GCrm.Application.Features.Commands.Definitions.ProjectType.Create
{
    public class CreateProjectTypeHandler : IRequestHandler<CreateProjectTypeRequest, CreateProjectTypeResponse>
    {
        readonly IProjectTypeWriteRepository _projectTypeWriteRepository;
        readonly IMapper _mapper;
        public CreateProjectTypeHandler(IProjectTypeWriteRepository projectTypeWriteRepository, IMapper mapper)
        {
            _projectTypeWriteRepository = projectTypeWriteRepository;
            _mapper = mapper;
        }

        public async  Task<CreateProjectTypeResponse> Handle(CreateProjectTypeRequest request, CancellationToken cancellationToken)
        {
            var projecttype = _mapper.Map<T.ProjectType>(request);

            projecttype = await _projectTypeWriteRepository.AddAsync(projecttype);
            await _projectTypeWriteRepository.SaveAsync();

            var createdResponse = _mapper.Map<CreateProjectTypeResponse>(projecttype);
            createdResponse.Message = CommandResponseMessage.AddedSuccess.ToString();

            return createdResponse;
        }
    }
}
