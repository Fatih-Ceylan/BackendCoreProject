using MediatR;

namespace BaseProject.Application.Features.Queries.Definitions.AddressType.GetById
{
    public class GetByIdAddressTypeRequest : IRequest<GetByIdAddressTypeResponse>
    {
        public string Id { get; set; }
    }
}
