using GCrm.Application.Repositories.ReadRepository;
using GCrm.Application.VMs.Definitions;
using GCrm.Application.VMs.Definitions.Files;
using MediatR;

namespace GCrm.Application.Features.Queries.Definitions.Project.GetAll
{
    public class GetAllProjectHandler : IRequestHandler<GetAllProjectRequest, GetAllProjectResponse>
    {
        readonly IProjectReadRepository _projectReadRepository;

        public GetAllProjectHandler(IProjectReadRepository projectReadRepository)
        {
            _projectReadRepository = projectReadRepository;
        }

        public Task<GetAllProjectResponse> Handle(GetAllProjectRequest request, CancellationToken cancellationToken)
        {
            var query = _projectReadRepository.GetAllDeletedStatusDesc(false)
        .Select(or => new ProjectVM
        {
            Id = or.Id.ToString(),
            ProjectName = or.ProjectName,
            CreatedDate = or.CreatedDate,
            Description = or.Description,
            ProjectPriorityEnum = or.ProjectPriorityEnum,
            ProjectStartDate = or.ProjectStartDate,
            ProjectFinishDate = or.ProjectFinishDate,
            CustomerId = or.CustomerId.ToString(),
            ProjectManagerId = or.ProjectManagerId.ToString(),
            ProjectStatuesId = or.ProjectStatuesId.ToString(),
            ProjectTeamId = or.ProjectTeamId.ToString(),
            ProjectTypeId = or.ProjectTypeId.ToString(),
            ProjectFiles = or.ProjectFiles
            .Where(sf => sf.IsDeleted == false)
            .Select(sf => new ProjectFileVM
            {
                Id = sf.Id.ToString(),
                FileName = sf.FileName,
                PathOrContainerName = sf.Path,
                Storage = sf.Storage,
                ProjectId = or.Id.ToString()
            }).ToList(),

        });

            var totalCount = query.Count();
            var projects = query.Skip(request.Page * request.Size)
                                 .Take(request.Size).ToList();

            return Task.FromResult(new GetAllProjectResponse
            {
                TotalCount = totalCount,
                Projects = projects,
            });
        }
    }
}
