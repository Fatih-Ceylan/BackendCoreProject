using MediatR;

namespace Platform.Application.Features.Commands.Definitions.License.Delete
{
    public class DeleteLicenseRequest : IRequest<DeleteLicenseResponse>
    {
        public string Id { get; set; }
    }
}
