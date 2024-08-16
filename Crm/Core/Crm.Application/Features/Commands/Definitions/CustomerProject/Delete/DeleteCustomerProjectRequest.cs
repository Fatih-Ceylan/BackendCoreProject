using MediatR;

namespace GCrm.Application.Features.Commands.Definitions.CustomerProject.Delete
{
    public class DeleteCustomerProjectRequest : IRequest<DeleteCustomerProjectResponse>
    {
        public string Id { get; set; }
    }
}
