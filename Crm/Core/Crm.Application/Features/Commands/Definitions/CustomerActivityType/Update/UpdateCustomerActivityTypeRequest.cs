using MediatR;

namespace GCrm.Application.Features.Commands.Definitions.CustomerActivityType.Update
{
    public class UpdateCustomerActivityTypeRequest : IRequest<UpdateCustomerActivityTypeResponse>
    {
        public string Id { get; set; }
        public string Name { get; set; }
    }
}
