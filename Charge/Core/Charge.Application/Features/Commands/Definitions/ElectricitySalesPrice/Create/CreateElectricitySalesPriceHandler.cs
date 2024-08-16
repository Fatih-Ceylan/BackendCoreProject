using AutoMapper;
using GCharge.Application.Repositories.WriteRepository.Definitions;
using MediatR;
using Utilities.Core.UtilityApplication.Enums;
using T = GCharge.Domain.Entities.Definitions;

namespace GCharge.Application.Features.Commands.Definitions.ElectricitySalesPrice.Create
{
    public class CreateElectricitySalesPriceHandler : IRequestHandler<CreateElectricitySalesPriceRequest, CreateElectricitySalesPriceResponse>
    {
        readonly IElectricitySalesPriceWriteRepository _electricitySalesPriceWriteRepository;
        readonly IMapper _mapper;

        public CreateElectricitySalesPriceHandler(IElectricitySalesPriceWriteRepository electricitySalesPriceWriteRepository, IMapper mapper)
        {
            _electricitySalesPriceWriteRepository = electricitySalesPriceWriteRepository;
            _mapper = mapper;
        }

        public async Task<CreateElectricitySalesPriceResponse> Handle(CreateElectricitySalesPriceRequest request, CancellationToken cancellationToken)
        {
            T.ElectricitySalesPrice electricitySalesPrice = _mapper.Map<T.ElectricitySalesPrice>(request);

            await _electricitySalesPriceWriteRepository.AddAsync(electricitySalesPrice);
            await _electricitySalesPriceWriteRepository.SaveAsync();

            var createdResponse = _mapper.Map<CreateElectricitySalesPriceResponse>(electricitySalesPrice);
            createdResponse.Message = CommandResponseMessage.AddedSuccess.ToString();

            return createdResponse;
        }
    }
}