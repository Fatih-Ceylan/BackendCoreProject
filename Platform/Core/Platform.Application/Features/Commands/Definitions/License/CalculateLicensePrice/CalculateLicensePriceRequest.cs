using MediatR;
using Platform.Domain.Entities.Enums;

namespace Platform.Application.Features.Commands.Definitions.License.CalculateLicensePrice
{
    public class CalculateLicensePriceRequest: IRequest<CalculateLicensePriceResponse>
    {
        public string CompanyId { get; set; }

        public string GModuleId { get; set; }

        public string LicenseTypeId { get; set; }

        public LicenseStatusEnum LicenseStatus { get; set; }

        public int TotalUserNumber { get; set; }

        public int TotalCompanyNumber { get; set; }

        public DateTime StartDate { get; set; }
    }
}