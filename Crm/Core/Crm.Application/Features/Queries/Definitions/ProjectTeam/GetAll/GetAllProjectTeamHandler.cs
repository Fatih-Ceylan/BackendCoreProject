using GCrm.Application.Repositories.ReadRepository;
using GCrm.Application.VMs.Definitions;
using MediatR;

namespace GCrm.Application.Features.Queries.Definitions.ProjectTeam.GetAll
{
    public class GetAllProjectTeamHandler : IRequestHandler<GetAllProjectTeamRequest, GetAllProjectTeamResponse>
    {
        readonly IProjectTeamReadRepository  _projectTeamReadRepository;

        public GetAllProjectTeamHandler(IProjectTeamReadRepository projectTeamReadRepository)
        {
            _projectTeamReadRepository= projectTeamReadRepository;

        }
        public Task<GetAllProjectTeamResponse> Handle(GetAllProjectTeamRequest request, CancellationToken cancellationToken)
        {
            var query = _projectTeamReadRepository.GetAllDeletedStatusDesc(false)
        .Select(pt => new ProjectTeamVM
        {
            Id = pt.Id.ToString(),

        });

            var totalCount = query.Count();
            var projectteams = query.Skip(request.Page * request.Size)
                                 .Take(request.Size).ToList();

            return Task.FromResult(new GetAllProjectTeamResponse
            {
                TotalCount = totalCount,
                ProjectTeams = projectteams,
            });
        }
    }
}
