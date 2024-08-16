using MediatR;

namespace Platform.Application.Features.Queries.Definitions.License.GetById
{
    public class GetByIdLicenseRequest : IRequest<GetByIdLicenseResponse>
    {
        public string Id { get; set; }
    }
}
