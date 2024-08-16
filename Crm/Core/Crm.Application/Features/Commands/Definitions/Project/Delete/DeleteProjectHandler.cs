using GCrm.Application.Repositories.WriteRepository;
using MediatR;
using Utilities.Core.UtilityApplication.Enums;

namespace GCrm.Application.Features.Commands.Definitions.Project.Delete
{
    public class DeleteProjectHandler : IRequestHandler<DeleteProjectRequest, DeleteProjectResponse>
    {
        readonly IProjectWriteRepository _projectWriteRepository;

        public DeleteProjectHandler(IProjectWriteRepository projectWriteRepository)
        {
            _projectWriteRepository = projectWriteRepository;
        }

        public async  Task<DeleteProjectResponse> Handle(DeleteProjectRequest request, CancellationToken cancellationToken)
        {
            await _projectWriteRepository.SoftDeleteAsync(request.Id);
            await _projectWriteRepository.SaveAsync();

            return new()
            {
                Message = CommandResponseMessage.DeletedSuccess.ToString(),
            };
        }
    }
}
