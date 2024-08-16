using MediatR;

namespace BaseProject.Application.Features.Commands.Definitions.AddressType.Delete
{
    public class DeleteAddressTypeRequest: IRequest<DeleteAddressTypeResponse>
    {
        public string Id { get; set; }

    }
}