using Card.Application.Repositories.ReadRepository;
using Card.Application.VMs;
using MediatR;

namespace Card.Application.Features.Queries.Definitions.Card.GetById
{
    public class GetByIdCardHandler : IRequestHandler<GetByIdCardRequest, GetByIdCardResponse>
    {
        readonly ICardReadRepository _cardReadRepository;

        public GetByIdCardHandler(ICardReadRepository cardReadRepository)
        {
            _cardReadRepository = cardReadRepository;
        }

        public async Task<GetByIdCardResponse> Handle(GetByIdCardRequest request, CancellationToken cancellationToken)
        {
            var card = _cardReadRepository
                            .GetWhere(c => c.Id == Guid.Parse(request.Id), false)
                            .Select(c => new CardVM
                            {
                                Id = c.Id.ToString(),
                                Name = c.Name,
                                CreatedDate = c.CreatedDate,
                                Price = c.Price,
                                TaxRate = c.TaxRate, 

                            }).FirstOrDefault();

            return new()
            {
                Card = card
            };
        }
    }
}
