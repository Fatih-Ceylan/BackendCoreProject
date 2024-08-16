using MediatR;

namespace GCrm.Application.Features.Commands.Definitions.CustomerProject.Update
{
    public class UpdateCustomerProjectRequest : IRequest<UpdateCustomerProjectResponse>
    {
        public string Id { get; set; }
    }
}
