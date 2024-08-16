using AutoMapper;
using GCrm.Application.Repositories.ReadRepository;
using GCrm.Application.Repositories.WriteRepository;
using MediatR;
using Utilities.Core.UtilityApplication.Enums;

namespace GCrm.Application.Features.Commands.Definitions.Project.Update
{
    public class UpdateProjectHandler : IRequestHandler<UpdateProjectRequest, UpdateProjectResponse>
    {
        readonly IProjectWriteRepository  _projectWriteRepository;
        readonly IProjectReadRepository  _projectReadRepository;
        readonly IMapper _mapper;

        public UpdateProjectHandler(IProjectWriteRepository projectWriteRepository, IProjectReadRepository projectReadRepository, IMapper mapper)
        {
            _projectWriteRepository = projectWriteRepository;
            _projectReadRepository = projectReadRepository;
            _mapper = mapper;
        }

        public async Task<UpdateProjectResponse> Handle(UpdateProjectRequest request, CancellationToken cancellationToken)
        {
            var project = await _projectReadRepository.GetByIdAsync(request.Id);
            project = _mapper.Map(request, project);
            await _projectWriteRepository.SaveAsync();

            var updatedResponse = _mapper.Map<UpdateProjectResponse>(project);
            updatedResponse.Message = CommandResponseMessage.UpdatedSuccess.ToString();

            return updatedResponse;
        }
    }
}
