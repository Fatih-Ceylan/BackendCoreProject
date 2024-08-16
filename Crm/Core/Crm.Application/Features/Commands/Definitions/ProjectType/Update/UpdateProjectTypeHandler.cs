using AutoMapper;
using GCrm.Application.Repositories.ReadRepository;
using GCrm.Application.Repositories.WriteRepository;
using MediatR;
using Utilities.Core.UtilityApplication.Enums;

namespace GCrm.Application.Features.Commands.Definitions.ProjectType.Update
{
    public class UpdateProjectTypeHandler : IRequestHandler<UpdateProjectTypeRequest, UpdateProjectTypeResponse>
    {
        readonly IProjectTypeWriteRepository _projectTypeWriteRepository;
        readonly IProjectTypeReadRepository _projectTypeReadRepository;
        readonly IMapper _mapper;

        public UpdateProjectTypeHandler(IProjectTypeWriteRepository projectTypeWriteRepository, IProjectTypeReadRepository projectTypeReadRepository, IMapper mapper)
        {
            _projectTypeWriteRepository = projectTypeWriteRepository;
            _projectTypeReadRepository = projectTypeReadRepository;
            _mapper = mapper;
        }

        public async  Task<UpdateProjectTypeResponse> Handle(UpdateProjectTypeRequest request, CancellationToken cancellationToken)
        {
            var projecttype = await _projectTypeReadRepository.GetByIdAsync(request.Id);
            projecttype = _mapper.Map(request, projecttype);
            await _projectTypeWriteRepository.SaveAsync();

            var updatedResponse = _mapper.Map<UpdateProjectTypeResponse>(projecttype);
            updatedResponse.Message = CommandResponseMessage.UpdatedSuccess.ToString();

            return updatedResponse;
        }
    }
}
