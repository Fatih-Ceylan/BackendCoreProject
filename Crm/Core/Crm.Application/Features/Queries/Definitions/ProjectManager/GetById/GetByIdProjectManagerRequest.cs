using MediatR;

namespace GCrm.Application.Features.Queries.Definitions.ProjectManager.GetById
{
    public class GetByIdProjectManagerRequest : IRequest<GetByIdProjectManagerResponse>
    {
        public string Id { get; set; }
    }
}
