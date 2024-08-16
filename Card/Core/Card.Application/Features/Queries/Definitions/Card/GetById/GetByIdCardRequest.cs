using MediatR;

namespace Card.Application.Features.Queries.Definitions.Card.GetById
{
    public class GetByIdCardRequest : IRequest<GetByIdCardResponse>
    {
        public string Id { get; set; }
    }
}
