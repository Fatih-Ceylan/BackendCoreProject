using AutoMapper;
using GCrm.Application.Repositories.ReadRepository;
using GCrm.Application.Repositories.WriteRepository;
using MediatR;
using Utilities.Core.UtilityApplication.Enums;

namespace GCrm.Application.Features.Commands.Definitions.ProjectManager.Update
{
    public class UpdateProjectManagerHandler : IRequestHandler<UpdateProjectManagerRequest, UpdateProjectManagerResponse>
    {
        readonly IProjectManagerWriteRepository  _projectManagerWriteRepository;
        readonly IProjectManagerReadRepository  _projectManagerReadRepository;
        readonly IMapper _mapper;

        public UpdateProjectManagerHandler(IProjectManagerWriteRepository projectManagerWriteRepository, IProjectManagerReadRepository projectManagerReadRepository, IMapper mapper)
        {
            _projectManagerWriteRepository = projectManagerWriteRepository;
            _projectManagerReadRepository = projectManagerReadRepository;
            _mapper = mapper;
        }

        public async  Task<UpdateProjectManagerResponse> Handle(UpdateProjectManagerRequest request, CancellationToken cancellationToken)
        {
            var projectmanager = await _projectManagerReadRepository.GetByIdAsync(request.Id);
            projectmanager = _mapper.Map(request, projectmanager);
            await _projectManagerWriteRepository.SaveAsync();

            var updatedResponse = _mapper.Map<UpdateProjectManagerResponse>(projectmanager);
            updatedResponse.Message = CommandResponseMessage.UpdatedSuccess.ToString();

            return updatedResponse;
        }
    }
}
