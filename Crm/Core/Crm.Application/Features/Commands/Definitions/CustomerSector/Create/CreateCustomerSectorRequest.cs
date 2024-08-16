using MediatR;
namespace GCrm.Application.Features.Commands.Definitions.CustomerSector.Create
{
    public class CreateCustomerSectorRequest : IRequest<CreateCustomerSectorResponse>
    {
        public string Name { get; set; }

    }
}
