using MediatR;

namespace GCrm.Application.Features.Commands.Definitions.CustomerProject.Create
{
    public class CreateCustomerProjectRequest : IRequest<CreateCustomerProjectResponse>
    {
        public string Name { get; set; }
    }
}
