using AutoMapper;
using Card.Application.Repositories.ReadRepository;
using Card.Application.Repositories.WriteRepository;
using MediatR;
using Utilities.Core.UtilityApplication.Enums;
using T = BaseProject.Domain.Entities.Card.Definitions;

namespace Card.Application.Features.Commands.Definitions.Card.Update
{
    public class UpdateCardHandler : IRequestHandler<UpdateCardRequest, UpdateCardResponse>
    {
        readonly ICardReadRepository _cardReadRepository;
        readonly ICardWriteRepository _cardWriteRepository;
        readonly IMapper _mapper;

        public UpdateCardHandler(ICardReadRepository cardReadRepository, ICardWriteRepository cardWriteRepository, IMapper mapper)
        {
            _cardReadRepository = cardReadRepository;
            _cardWriteRepository = cardWriteRepository;
            _mapper = mapper;
        }

        public async Task<UpdateCardResponse> Handle(UpdateCardRequest request, CancellationToken cancellationToken)
        {
            T.Card card = await _cardReadRepository.GetByIdAsync(request.Id);
            card = _mapper.Map(request, card);
            await _cardWriteRepository.SaveAsync();

            var updatedResponse = _mapper.Map<UpdateCardResponse>(card);
            updatedResponse.Message = CommandResponseMessage.UpdatedSuccess.ToString();

            return updatedResponse;
        }
    }
}
