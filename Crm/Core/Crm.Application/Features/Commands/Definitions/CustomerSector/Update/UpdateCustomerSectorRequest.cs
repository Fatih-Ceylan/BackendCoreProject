using MediatR;

namespace GCrm.Application.Features.Commands.Definitions.CustomerSector.Update
{
    public class UpdateCustomerSectorRequest : IRequest<UpdateCustomerSectorResponse>
    {
        public string Id { get; set; }

        public string Name { get; set; }
    }
}
