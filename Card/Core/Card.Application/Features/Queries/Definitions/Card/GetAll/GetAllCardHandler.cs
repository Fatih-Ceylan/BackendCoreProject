
using Card.Application.Repositories.ReadRepository;
using Card.Application.VMs;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Utilities.Core.UtilityApplication.Abstractions.Services.RabbitMQ;
using T = BaseProject.Domain.Entities.Card.Definitions;

namespace Card.Application.Features.Queries.Definitions.Card.GetAll
{
    public class GetAllCardHandler : IRequestHandler<GetAllCardRequest, GetAllCardResponse>
    {
        readonly ICardReadRepository _cardReadRepository;
        readonly IRabbitMQProducer _rabbitMQProducer;

        public GetAllCardHandler(ICardReadRepository cardReadRepository, IRabbitMQProducer rabbitMQProducer)
        {
            _cardReadRepository = cardReadRepository;
            _rabbitMQProducer = rabbitMQProducer;
        }

        public async Task<GetAllCardResponse> Handle(GetAllCardRequest request, CancellationToken cancellationToken)
        {
            IQueryable<T.Card> cardQuery = _cardReadRepository.GetAllDeletedStatusDesc(false); 
            var cards = await _cardReadRepository.GetAllDeletedStatusDesc(false).Select(c => new CardVM
            {
                Id = c.Id.ToString(),
                Name = c.Name,
                CreatedDate = c.CreatedDate,
                Price = c.Price,
                TaxRate = c.TaxRate, 
            }).ToListAsync(cancellationToken);

            var totalCount = cards.Count;
            var response = cards.Skip(request.Page * request.Size).Take(request.Size).ToList();

            _rabbitMQProducer.SendMessage("İlk mesaj");
            return new GetAllCardResponse
            {
                TotalCount = totalCount,
                Cards = response
            };
        }
    }
}
