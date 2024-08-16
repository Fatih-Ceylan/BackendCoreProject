using MediatR;

namespace Platform.Application.Features.Commands.Definitions.LicenseType.Update
{
    public class UpdateLicenseTypeRequest : IRequest<UpdateLicenseTypeResponse>
    {
       public string Id { get; set; }

        public string Name { get; set; }

        public int UsageMounth { get; set; }

        public int UserNumber { get; set; }

        public int CompanyNumber { get; set; }

    }
}