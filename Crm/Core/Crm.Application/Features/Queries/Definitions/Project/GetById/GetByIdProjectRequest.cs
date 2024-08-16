using MediatR;

namespace GCrm.Application.Features.Queries.Definitions.Project.GetById
{
    public  class GetByIdProjectRequest : IRequest<GetByIdProjectResponse>
    {
        public string Id { get; set; }
    }
}
