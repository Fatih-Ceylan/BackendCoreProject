using GCrm.Application.Repositories.ReadRepository;
using GCrm.Application.VMs.Definitions;
using MediatR;

namespace GCrm.Application.Features.Queries.Definitions.Project.GetById
{
    public class GetByIdProjectHandler : IRequestHandler<GetByIdProjectRequest, GetByIdProjectResponse>
    {
        readonly IProjectReadRepository  _projectReadRepository;

        public GetByIdProjectHandler(IProjectReadRepository projectReadRepository)
        {
            _projectReadRepository = projectReadRepository;
        }

        public async  Task<GetByIdProjectResponse> Handle(GetByIdProjectRequest request, CancellationToken cancellationToken)
        {
            var projects = _projectReadRepository
                   .GetWhere(ct => ct.Id == Guid.Parse(request.Id), false)
                   .Select(ct => new ProjectVM
                   {
                       Id = ct.Id.ToString(),

                   }).FirstOrDefault();

            return new()
            {
                Project = projects
            };
        }
    }
}
