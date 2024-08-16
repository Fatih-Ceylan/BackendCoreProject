using AutoMapper;
using MediatR;
using Platform.Application.Repositories.WriteRepository.Definitions;
using Utilities.Core.UtilityApplication.Enums;
using T = Platform.Domain.Entities.Definitions;

namespace Platform.Application.Features.Commands.Definitions.SpecialOffer.Create
{
    public class CreateSpecialOfferHandler : IRequestHandler<CreateSpecialOfferRequest, CreateSpecialOfferResponse>
    {
        readonly ISpecialOfferWriteRepository _specialOfferWriteRepository;
        readonly IMapper _mapper;

        public CreateSpecialOfferHandler(ISpecialOfferWriteRepository specialOfferWriteRepository, IMapper mapper)
        {
            _specialOfferWriteRepository = specialOfferWriteRepository;
            _mapper = mapper;
        }

        public async Task<CreateSpecialOfferResponse> Handle(CreateSpecialOfferRequest request, CancellationToken cancellationToken)
        {
            var specialOffer = _mapper.Map<T.SpecialOffer>(request);

            specialOffer = await _specialOfferWriteRepository.AddAsync(specialOffer);
            await _specialOfferWriteRepository.SaveAsync();

            var createdResponse = _mapper.Map<CreateSpecialOfferResponse>(specialOffer);
            createdResponse.Message = CommandResponseMessage.AddedSuccess.ToString();

            return createdResponse;
        }
    }
}
