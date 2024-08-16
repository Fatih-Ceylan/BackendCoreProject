using MediatR;

namespace Card.Application.Features.Queries.Definitions.Address.GetById
{
    public class GetByIdAddressRequest : IRequest<GetByIdAddressResponse>
    {
        public string Id { get; set; }
    }
}
