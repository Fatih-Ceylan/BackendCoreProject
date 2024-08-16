using AutoMapper;
using MediatR;
using Platform.Application.Repositories.ReadRepository.Definitions;
using Platform.Application.Repositories.WriteRepository.Definitions;
using Utilities.Core.UtilityApplication.Enums;

namespace Platform.Application.Features.Commands.Definitions.SpecialOffer.Update
{
    public class UpdateSpecialOfferHandler : IRequestHandler<UpdateSpecialOfferRequest, UpdateSpecialOfferResponse>
    {
        readonly ISpecialOfferReadRepository _specialOfferReadRepository;
        readonly ISpecialOfferWriteRepository _specialOfferWriteRepository;
        readonly IMapper _mapper;

        public UpdateSpecialOfferHandler(ISpecialOfferReadRepository specialOfferReadRepository, ISpecialOfferWriteRepository specialOfferWriteRepository, IMapper mapper)
        {
            _specialOfferReadRepository = specialOfferReadRepository;
            _specialOfferWriteRepository = specialOfferWriteRepository;
            _mapper = mapper;
        }

        public async Task<UpdateSpecialOfferResponse> Handle(UpdateSpecialOfferRequest request, CancellationToken cancellationToken)
        {
            var specialOffer = await _specialOfferReadRepository.GetByIdAsync(request.Id);
            specialOffer = _mapper.Map(request, specialOffer);

            await _specialOfferWriteRepository.SaveAsync();

            var updatedResponse = _mapper.Map<UpdateSpecialOfferResponse>(specialOffer);
            updatedResponse.Message = CommandResponseMessage.UpdatedSuccess.ToString();

            return updatedResponse;
        }
    }
}
