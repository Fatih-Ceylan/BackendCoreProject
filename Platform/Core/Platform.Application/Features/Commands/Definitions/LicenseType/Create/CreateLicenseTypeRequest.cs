using MediatR;

namespace Platform.Application.Features.Commands.Definitions.LicenseType.Create
{
    public class CreateLicenseTypeRequest : IRequest<CreateLicenseTypeResponse>
    {
        public string Name { get; set; }

        public int UsageMounth { get; set; }

        public int UserNumber { get; set; }

        public int CompanyNumber { get; set; }
    }
}