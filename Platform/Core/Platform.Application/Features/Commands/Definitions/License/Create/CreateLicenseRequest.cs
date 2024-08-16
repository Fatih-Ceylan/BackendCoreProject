using MediatR;
using Platform.Application.VMs.Definitions.LicenseDetail;
using Platform.Domain.Entities.Enums;

namespace Platform.Application.Features.Commands.Definitions.License.Create
{
    public class CreateLicenseRequest : IRequest<CreateLicenseResponse>
    {
        public string CompanyId { get; set; }

        public string GModuleId { get; set; }

        public string LicenseTypeId { get; set; }

        public LicenseStatusEnum LicenseStatus { get; set; }

        public int TotalUserNumber { get; set; }

        public int TotalCompanyNumber { get; set; }

        public DateTime StartDate { get; set; }

        public List<CreateLicenseDetailVM> LicenseDetails { get; set; }
    }
}