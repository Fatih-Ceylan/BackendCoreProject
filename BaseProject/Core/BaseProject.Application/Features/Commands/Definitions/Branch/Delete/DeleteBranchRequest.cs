using MediatR;

namespace BaseProject.Application.Features.Commands.Definitions.Branch.Delete
{
    public class DeleteBranchRequest : IRequest<DeleteBranchResponse>
    {
        public string Id { get; set; }
    }
}
