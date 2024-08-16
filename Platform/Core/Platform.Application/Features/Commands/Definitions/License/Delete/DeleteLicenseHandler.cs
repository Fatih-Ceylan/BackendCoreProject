using MediatR;
using Platform.Application.Repositories.WriteRepository.Definitions;
using Utilities.Core.UtilityApplication.Enums;

namespace Platform.Application.Features.Commands.Definitions.License.Delete
{
    public class DeleteLicenseHandler : IRequestHandler<DeleteLicenseRequest, DeleteLicenseResponse>
    {
        readonly ILicenseWriteRepository _LicenseWriteRepository;

        public DeleteLicenseHandler(ILicenseWriteRepository LicenseWriteRepository)
        {
            _LicenseWriteRepository = LicenseWriteRepository;
        }

        public async Task<DeleteLicenseResponse> Handle(DeleteLicenseRequest request, CancellationToken cancellationToken)
        {
            await _LicenseWriteRepository.SoftDeleteAsync(request.Id);
            await _LicenseWriteRepository.SaveAsync();

            return new()
            {
                Message = CommandResponseMessage.DeletedSuccess.ToString()
            };
        }

    }
}
