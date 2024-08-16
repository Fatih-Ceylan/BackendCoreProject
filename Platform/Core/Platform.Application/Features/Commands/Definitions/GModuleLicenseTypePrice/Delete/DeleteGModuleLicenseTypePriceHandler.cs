using MediatR;
using Platform.Application.Repositories.WriteRepository.Definitions;
using Utilities.Core.UtilityApplication.Enums;

namespace Platform.Application.Features.Commands.Definitions.GModuleLicenseTypePrice.Delete
{
    public class DeleteGModuleLicenseTypePriceHandler : IRequestHandler<DeleteGModuleLicenseTypePriceRequest, DeleteGModuleLicenseTypePriceResponse>
    {
        readonly IGModuleLicenseTypePriceWriteRepository _gModuleLicenseTypePriceWriteRepository;

        public DeleteGModuleLicenseTypePriceHandler(IGModuleLicenseTypePriceWriteRepository gModuleLicenseTypePriceWriteRepository)
        {
            _gModuleLicenseTypePriceWriteRepository = gModuleLicenseTypePriceWriteRepository;
        }

        public async Task<DeleteGModuleLicenseTypePriceResponse> Handle(DeleteGModuleLicenseTypePriceRequest request, CancellationToken cancellationToken)
        {
            await _gModuleLicenseTypePriceWriteRepository.SoftDeleteAsync(request.Id);
            await _gModuleLicenseTypePriceWriteRepository.SaveAsync();

            return new()
            {
                Message = CommandResponseMessage.DeletedSuccess.ToString(),
            };
        }
    }
}