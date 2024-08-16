using MediatR;

namespace Platform.Application.Features.Commands.Definitions.License.Update
{
    public class UpdateLicenseRequest : IRequest<UpdateLicenseResponse>
    {
        public string Id { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime ExpirationDate { get; set; }
    }
}
