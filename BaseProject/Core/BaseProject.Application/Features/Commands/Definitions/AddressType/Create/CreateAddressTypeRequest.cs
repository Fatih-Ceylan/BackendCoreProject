using MediatR;

namespace BaseProject.Application.Features.Commands.Definitions.AddressType.Create
{
    public class CreateAddressTypeRequest: IRequest<CreateAddressTypeResponse>
    {
        public string Name { get; set; }
    }
}