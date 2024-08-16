using AutoMapper;
using MediatR;
using Platform.Application.Repositories.WriteRepository.Definitions;
using Utilities.Core.UtilityApplication.Enums;
using T = Platform.Domain.Entities.Definitions;

namespace Platform.Application.Features.Commands.Definitions.GModuleLicenseTypePrice.Create
{
    public class CreateGModuleLicenseTypePriceHandler : IRequestHandler<CreateGModuleLicenseTypePriceRequest, CreateGModuleLicenseTypePriceResponse>
    {
        readonly IGModuleLicenseTypePriceWriteRepository _gModuleLicenseTypePriceWriteRepository;
        readonly IMapper _mapper;
        public CreateGModuleLicenseTypePriceHandler(IGModuleLicenseTypePriceWriteRepository gModuleLicenseTypePriceWriteRepository, IMapper mapper)
        {
            _gModuleLicenseTypePriceWriteRepository = gModuleLicenseTypePriceWriteRepository;
            _mapper = mapper;
        }

        public async Task<CreateGModuleLicenseTypePriceResponse> Handle(CreateGModuleLicenseTypePriceRequest request, CancellationToken cancellationToken)
        {
            T.GModuleLicenseTypePrice gModuleLicenseTypePrice = _mapper.Map<T.GModuleLicenseTypePrice>(request);

            gModuleLicenseTypePrice = await _gModuleLicenseTypePriceWriteRepository.AddAsync(gModuleLicenseTypePrice);
            await _gModuleLicenseTypePriceWriteRepository.SaveAsync();

            var createdResponse = _mapper.Map<CreateGModuleLicenseTypePriceResponse>(gModuleLicenseTypePrice);
            createdResponse.Message = CommandResponseMessage.AddedSuccess.ToString();

            return createdResponse;
        }
    }
}