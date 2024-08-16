using MediatR;

namespace Platform.Application.Features.Commands.Definitions.LicenseType.Delete
{
    public class DeleteLicenseTypeRequest : IRequest<DeleteLicenseTypeResponse>
    {
        public string Id { get; set; }
    }
}