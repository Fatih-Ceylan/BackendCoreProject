using GCrm.Application.Repositories.ReadRepository;
using GCrm.Application.VMs.Definitions;
using MediatR;

namespace GCrm.Application.Features.Queries.Definitions.ProjectTeam.GetById
{
    public class GetByIdProjectTeamHandler : IRequestHandler<GetByIdProjectTeamRequest, GetByIdProjectTeamResponse>
    {
        readonly IProjectTeamReadRepository  _projectTeamReadRepository;

        public GetByIdProjectTeamHandler(IProjectTeamReadRepository projectTeamReadRepository)
        {
            _projectTeamReadRepository = projectTeamReadRepository;
        }

        public async  Task<GetByIdProjectTeamResponse> Handle(GetByIdProjectTeamRequest request, CancellationToken cancellationToken)
        {
            var projectteams = _projectTeamReadRepository
              .GetWhere(ct => ct.Id == Guid.Parse(request.Id), false)
              .Select(ct => new ProjectTeamVM
              {
                  Id = ct.Id.ToString(),

              }).FirstOrDefault();

            return new()
            {
                ProjectTeam = projectteams
            };
        }
    }
}
