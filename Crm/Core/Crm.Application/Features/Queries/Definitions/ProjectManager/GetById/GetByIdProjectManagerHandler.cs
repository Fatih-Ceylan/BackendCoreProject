using GCrm.Application.Repositories.ReadRepository;
using GCrm.Application.VMs.Definitions;
using MediatR;

namespace GCrm.Application.Features.Queries.Definitions.ProjectManager.GetById
{
    public class GetByIdProjectManagerHandler : IRequestHandler<GetByIdProjectManagerRequest, GetByIdProjectManagerResponse>
    {
        readonly IProjectManagerReadRepository  _projectManagerReadRepository;
        public GetByIdProjectManagerHandler(IProjectManagerReadRepository projectManagerReadRepository)
        {
            _projectManagerReadRepository=projectManagerReadRepository;
        }
        public async  Task<GetByIdProjectManagerResponse> Handle(GetByIdProjectManagerRequest request, CancellationToken cancellationToken)
        {
            var projectmanagers = _projectManagerReadRepository
                 .GetWhere(ct => ct.Id == Guid.Parse(request.Id), false)
                 .Select(ct => new ProjectManagerVM
                 {
                     Id = ct.Id.ToString(),

                 }).FirstOrDefault();

            return new()
            {
                ProjectManager = projectmanagers
            };
        }
    }
}
