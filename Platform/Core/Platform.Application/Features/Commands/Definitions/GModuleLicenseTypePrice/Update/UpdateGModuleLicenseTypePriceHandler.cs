using AutoMapper;
using MediatR;
using Platform.Application.Repositories.ReadRepository.Definitions;
using Platform.Application.Repositories.WriteRepository.Definitions;
using Utilities.Core.UtilityApplication.Enums;

namespace Platform.Application.Features.Commands.Definitions.GModuleLicenseTypePrice.Update
{
    public class UpdateGModuleLicenseTypePriceHandler : IRequestHandler<UpdateGModuleLicenseTypePriceRequest, UpdateGModuleLicenseTypePriceResponse>
    {
        readonly IGModuleLicenseTypePriceReadRepository _gModuleLicenseTypePriceReadRepository;
        readonly IGModuleLicenseTypePriceWriteRepository _gModuleLicenseTypePriceWriteRepository;
        readonly IMapper _mapper;

        public UpdateGModuleLicenseTypePriceHandler(IGModuleLicenseTypePriceReadRepository gModuleLicenseTypePriceReadRepository, IGModuleLicenseTypePriceWriteRepository gModuleLicenseTypePriceWriteRepository, IMapper mapper)
        {
            _gModuleLicenseTypePriceReadRepository = gModuleLicenseTypePriceReadRepository;
            _gModuleLicenseTypePriceWriteRepository = gModuleLicenseTypePriceWriteRepository;
            _mapper = mapper;
        }

        public async Task<UpdateGModuleLicenseTypePriceResponse> Handle(UpdateGModuleLicenseTypePriceRequest request, CancellationToken cancellationToken)
        {
            var gModuleLicenseTypePrice = await _gModuleLicenseTypePriceReadRepository.GetByIdAsync(request.Id);
            gModuleLicenseTypePrice = _mapper.Map(request, gModuleLicenseTypePrice);
            await _gModuleLicenseTypePriceWriteRepository.SaveAsync();

            var updatedResponse = _mapper.Map<UpdateGModuleLicenseTypePriceResponse>(gModuleLicenseTypePrice);
            updatedResponse.Message = CommandResponseMessage.UpdatedSuccess.ToString();

            return updatedResponse;
        }
    }
}