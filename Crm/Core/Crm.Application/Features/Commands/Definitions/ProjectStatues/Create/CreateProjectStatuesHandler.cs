using AutoMapper;
using GCrm.Application.Repositories.WriteRepository;
using MediatR;
using Utilities.Core.UtilityApplication.Enums;

namespace GCrm.Application.Features.Commands.Definitions.ProjectStatues.Create
{
    public class CreateProjectStatuesHandler : IRequestHandler<CreateProjectStatuesRequest, CreateProjectStatuesResponse>
    {
        readonly IProjectStatuesWriteRepository _projectStatuesWriteRepository;
        readonly IMapper _mapper;

        public CreateProjectStatuesHandler(IProjectStatuesWriteRepository projectStatuesWriteRepository, IMapper mapper)
        {
            _projectStatuesWriteRepository = projectStatuesWriteRepository;
            _mapper=mapper;
        }

        public async  Task<CreateProjectStatuesResponse> Handle(CreateProjectStatuesRequest request, CancellationToken cancellationToken)
        {
            var projectstatues = _mapper.Map<BaseProject.Domain.Entities.GCrm.Definitions.ProjectManagement.Projects.ProjectStatues>(request);

            projectstatues = await _projectStatuesWriteRepository.AddAsync(projectstatues);
            await _projectStatuesWriteRepository.SaveAsync();

            var createdResponse = _mapper.Map<CreateProjectStatuesResponse>(projectstatues);
            createdResponse.Message = CommandResponseMessage.AddedSuccess.ToString();

            return createdResponse;
        }
    }
}
