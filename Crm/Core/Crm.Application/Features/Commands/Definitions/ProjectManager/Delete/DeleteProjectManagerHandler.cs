using GCrm.Application.Repositories.WriteRepository;
using MediatR;
using Utilities.Core.UtilityApplication.Enums;

namespace GCrm.Application.Features.Commands.Definitions.ProjectManager.Delete
{
    public class DeleteProjectManagerHandler : IRequestHandler<DeleteProjectManagerRequest, DeleteProjectManagerResponse>
    {
        readonly IProjectManagerWriteRepository  _projectManagerWriteRepository;

        public DeleteProjectManagerHandler(IProjectManagerWriteRepository projectManagerWriteRepository)
        {
            _projectManagerWriteRepository = projectManagerWriteRepository;
        }

        public async  Task<DeleteProjectManagerResponse> Handle(DeleteProjectManagerRequest request, CancellationToken cancellationToken)
        {
            await _projectManagerWriteRepository.SoftDeleteAsync(request.Id);
            await _projectManagerWriteRepository.SaveAsync();

            return new()
            {
                Message = CommandResponseMessage.DeletedSuccess.ToString(),
            };
        }
    }
}
