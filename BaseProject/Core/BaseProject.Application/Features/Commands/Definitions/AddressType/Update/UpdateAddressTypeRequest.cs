using MediatR;

namespace BaseProject.Application.Features.Commands.Definitions.AddressType.Update
{
    public class UpdateAddressTypeRequest: IRequest<UpdateAddressTypeResponse>
    {
        public string Id { get; set; }

        public string Name { get; set; }
    }
}