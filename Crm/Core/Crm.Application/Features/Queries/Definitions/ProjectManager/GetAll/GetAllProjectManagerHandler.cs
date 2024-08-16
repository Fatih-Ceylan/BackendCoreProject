using GCrm.Application.Repositories.ReadRepository;
using GCrm.Application.VMs.Definitions;
using MediatR;

namespace GCrm.Application.Features.Queries.Definitions.ProjectManager.GetAll
{
    public class GetAllProjectManagerHandler : IRequestHandler<GetAllProjectManagerRequest, GetAllProjectManagerResponse>
    {
        readonly IProjectManagerReadRepository _projectManagerReadRepository;
        public GetAllProjectManagerHandler(IProjectManagerReadRepository projectManagerReadRepository)
        {
            _projectManagerReadRepository = projectManagerReadRepository;
        }

        public Task<GetAllProjectManagerResponse> Handle(GetAllProjectManagerRequest request, CancellationToken cancellationToken)
        {

              var query = _projectManagerReadRepository.GetAllDeletedStatusDesc(false)
                .Select(or => new ProjectManagerVM
            {
               Id = or.Id.ToString(),
               

             });

            var totalCount = query.Count();
            var projectmanagers = query.Skip(request.Page * request.Size)
                                 .Take(request.Size).ToList();

            return Task.FromResult(new GetAllProjectManagerResponse
            {
                TotalCount = totalCount,
                ProjectManagers = projectmanagers,
            });
        }
    }
}
