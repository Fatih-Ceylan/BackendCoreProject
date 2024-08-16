using MediatR;

namespace BaseProject.Application.Features.Queries.Definitions.Branch.GetById
{
    public class GetByIdBranchRequest : IRequest<GetByIdBranchResponse>
    {
        public string Id { get; set; }
    }
}
