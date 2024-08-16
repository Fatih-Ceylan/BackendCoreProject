using GCrm.Application.Repositories.WriteRepository;
using MediatR;
using Utilities.Core.UtilityApplication.Enums;

namespace GCrm.Application.Features.Commands.Definitions.ProjectStatues.Delete
{
    public class DeleteProjectStatuesHandler : IRequestHandler<DeleteProjectStatuesRequest, DeleteProjectStatuesResponse>
    {
        readonly IProjectStatuesWriteRepository _projectStatuesWriteRepository;

        public DeleteProjectStatuesHandler(IProjectStatuesWriteRepository projectStatuesWriteRepository)
        {
            _projectStatuesWriteRepository = projectStatuesWriteRepository;
        }

        public async  Task<DeleteProjectStatuesResponse> Handle(DeleteProjectStatuesRequest request, CancellationToken cancellationToken)
        {
            await _projectStatuesWriteRepository.SoftDeleteAsync(request.Id);
            await _projectStatuesWriteRepository.SaveAsync();

            return new()
            {
                Message = CommandResponseMessage.DeletedSuccess.ToString(),
            };
        }
    }
}
