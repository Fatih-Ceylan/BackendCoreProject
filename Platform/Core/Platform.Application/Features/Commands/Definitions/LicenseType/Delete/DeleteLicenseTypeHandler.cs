using MediatR;
using Platform.Application.Repositories.WriteRepository.Definitions;
using Utilities.Core.UtilityApplication.Enums;

namespace Platform.Application.Features.Commands.Definitions.LicenseType.Delete
{
    public class DeleteLicenseTypeHandler : IRequestHandler<DeleteLicenseTypeRequest, DeleteLicenseTypeResponse>
    {
        ILicenseTypeWriteRepository _licenseTypeWriteRepository;

        public DeleteLicenseTypeHandler(ILicenseTypeWriteRepository licenseTypeWriteRepository)
        {
            _licenseTypeWriteRepository = licenseTypeWriteRepository;
        }

        public async Task<DeleteLicenseTypeResponse> Handle(DeleteLicenseTypeRequest request, CancellationToken cancellationToken)
        {
            await _licenseTypeWriteRepository.SoftDeleteAsync(request.Id);
            await _licenseTypeWriteRepository.SaveAsync();

            return new()
            {
                Message = CommandResponseMessage.DeletedSuccess.ToString(),
            };
        }
    }
}