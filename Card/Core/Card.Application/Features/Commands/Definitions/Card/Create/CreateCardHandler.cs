using AutoMapper;
using Card.Application.Repositories.WriteRepository;
using MediatR;
using Utilities.Core.UtilityApplication.Enums;
using T = BaseProject.Domain.Entities.Card.Definitions;

namespace Card.Application.Features.Commands.Definitions.Card.Create
{
    public class CreateCardHandler : IRequestHandler<CreateCardRequest, CreateCardResponse>
    {
        readonly ICardWriteRepository _cardWriteRepository;
        readonly IMapper _mapper;

        public CreateCardHandler(ICardWriteRepository cardWriteRepository, IMapper mapper)
        {
            _cardWriteRepository = cardWriteRepository;
            _mapper = mapper;
        }

        public async Task<CreateCardResponse> Handle(CreateCardRequest request, CancellationToken cancellationToken)
        {
            T.Card card = _mapper.Map<T.Card>(request);

            await _cardWriteRepository.AddAsync(card);
            await _cardWriteRepository.SaveAsync();

            var createdResponse = _mapper.Map<CreateCardResponse>(card);
            createdResponse.Message = CommandResponseMessage.AddedSuccess.ToString();
            createdResponse.TaxRate = card.TaxRate;
            createdResponse.Id = card.Id.ToString();
            createdResponse.Price = card.Price;
            //createdResponse.BranchId = card.BaseProjectBranchId.ToString();
            //createdResponse.CompanyId = card.BaseProjectCompanyId.ToString();

            return createdResponse;
        }
    }
}
