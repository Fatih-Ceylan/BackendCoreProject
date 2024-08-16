using AutoMapper;
using GCharge.Application.Repositories.WriteRepository.Definitions;
using MediatR;
using Utilities.Core.UtilityApplication.Enums;
using T = GCharge.Domain.Entities.Definitions;

namespace GCharge.Application.Features.Commands.Definitions.ChargeTag.Create
{
    public class CreateChargeTagHandler : IRequestHandler<CreateChargeTagRequest, CreateChargeTagResponse>
    {
        readonly IChargeTagWriteRepository _chargeTagWriteRepository;
        readonly IMapper _mapper;

        public CreateChargeTagHandler(IChargeTagWriteRepository chargeTagWriteRepository, IMapper mapper)
        {
            _chargeTagWriteRepository = chargeTagWriteRepository;
            _mapper = mapper;
        }

        public async Task<CreateChargeTagResponse> Handle(CreateChargeTagRequest request, CancellationToken cancellationToken)
        {
            T.ChargeTag chargeTag = _mapper.Map<T.ChargeTag>(request);

            await _chargeTagWriteRepository.AddAsync(chargeTag);
            await _chargeTagWriteRepository.SaveAsync();

            var createdResponse = _mapper.Map<CreateChargeTagResponse>(chargeTag);
            createdResponse.Message = CommandResponseMessage.AddedSuccess.ToString();

            return createdResponse;
        }
    }
}
