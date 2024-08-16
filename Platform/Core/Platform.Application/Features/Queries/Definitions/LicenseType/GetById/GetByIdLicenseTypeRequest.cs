using MediatR;

namespace Platform.Application.Features.Queries.Definitions.LicenseType.GetById
{
    public class GetByIdLicenseTypeRequest : IRequest<GetByIdLicenseTypeResponse>
    {
        public string Id { get; set; }
    }
}