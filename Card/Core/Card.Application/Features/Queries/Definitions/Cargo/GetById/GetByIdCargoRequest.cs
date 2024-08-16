using MediatR;

namespace Card.Application.Features.Queries.Definitions.Cargo.GetById
{
    public class GetByIdCargoRequest : IRequest<GetByIdCargoResponse>
    {
        public string Id { get; set; }
    }
}
