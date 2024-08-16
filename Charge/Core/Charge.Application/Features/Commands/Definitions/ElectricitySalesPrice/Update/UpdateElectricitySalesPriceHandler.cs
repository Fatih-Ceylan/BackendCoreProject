using AutoMapper;
using GCharge.Application.Repositories.ReadRepository.Definitions;
using GCharge.Application.Repositories.WriteRepository.Definitions;
using MediatR;
using Utilities.Core.UtilityApplication.Enums;

namespace GCharge.Application.Features.Commands.Definitions.ElectricitySalesPrice.Update
{
    public class UpdateElectricitySalesPriceHandler : IRequestHandler<UpdateElectricitySalesPriceRequest, UpdateElectricitySalesPriceResponse>
    {
        readonly IElectricitySalesPriceReadRepository _electricitySalesPriceReadRepository;
        readonly IElectricitySalesPriceWriteRepository _electricitySalesPriceWriteRepository;
        readonly IMapper _mapper;
        public UpdateElectricitySalesPriceHandler(IElectricitySalesPriceReadRepository electricitySalesPriceReadRepository, IElectricitySalesPriceWriteRepository electricitySalesPriceWriteRepository, IMapper mapper)
        {
            _electricitySalesPriceReadRepository = electricitySalesPriceReadRepository;
            _electricitySalesPriceWriteRepository = electricitySalesPriceWriteRepository;
            _mapper = mapper;

        }
        public async Task<UpdateElectricitySalesPriceResponse> Handle(UpdateElectricitySalesPriceRequest request, CancellationToken cancellationToken)
        {
            var customeractivitystatus = await _electricitySalesPriceReadRepository.GetByIdAsync(request.Id);
            customeractivitystatus = _mapper.Map(request, customeractivitystatus);
            await _electricitySalesPriceWriteRepository.SaveAsync();

            var updatedResponse = _mapper.Map<UpdateElectricitySalesPriceResponse>(customeractivitystatus);
            updatedResponse.Message = CommandResponseMessage.UpdatedSuccess.ToString();

            return updatedResponse;
        }
    }
}
