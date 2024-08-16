using GCrm.Application.Repositories.WriteRepository;
using MediatR;
using Utilities.Core.UtilityApplication.Enums;

namespace GCrm.Application.Features.Commands.Definitions.ProjectTeam.Delete
{
    public class DeleteProjectTeamHandler : IRequestHandler<DeleteProjectTeamRequest, DeleteProjectTeamResponse>
    {
        readonly IProjectTeamWriteRepository  _projectTeamWriteRepository;

        public DeleteProjectTeamHandler(IProjectTeamWriteRepository projectTeamWriteRepository)
        {
            _projectTeamWriteRepository = projectTeamWriteRepository;
        }

        public async Task<DeleteProjectTeamResponse> Handle(DeleteProjectTeamRequest request, CancellationToken cancellationToken)
        {
            await _projectTeamWriteRepository.SoftDeleteAsync(request.Id);
            await _projectTeamWriteRepository.SaveAsync();

            return new()
            {
                Message = CommandResponseMessage.DeletedSuccess.ToString(),
            };
        }
    }
}
