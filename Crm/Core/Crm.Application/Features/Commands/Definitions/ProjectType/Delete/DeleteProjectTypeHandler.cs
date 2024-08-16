using GCrm.Application.Repositories.WriteRepository;
using MediatR;
using Utilities.Core.UtilityApplication.Enums;

namespace GCrm.Application.Features.Commands.Definitions.ProjectType.Delete
{
    public class DeleteProjectTypeHandler : IRequestHandler<DeleteProjectTypeRequest, DeleteProjectTypeResponse>
    {
        readonly IProjectTypeWriteRepository _projectTypeWriteRepository;

        public DeleteProjectTypeHandler(IProjectTypeWriteRepository projectTypeWriteRepository)
        {

            _projectTypeWriteRepository= projectTypeWriteRepository;
        }
        public async  Task<DeleteProjectTypeResponse> Handle(DeleteProjectTypeRequest request, CancellationToken cancellationToken)
        {
            await _projectTypeWriteRepository.SoftDeleteAsync(request.Id);
            await _projectTypeWriteRepository.SaveAsync();

            return new()
            {
                Message = CommandResponseMessage.DeletedSuccess.ToString(),
            };
        }
    }
}
