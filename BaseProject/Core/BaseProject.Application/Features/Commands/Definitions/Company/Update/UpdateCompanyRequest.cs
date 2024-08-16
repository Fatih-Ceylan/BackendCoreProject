using BaseProject.Application.VMs.Definitions.CompanyAddress;
using BaseProject.Application.VMs.Definitions.CompanyLicense;
using MediatR;
using Utilities.Core.UtilityApplication.DTOs.File;

namespace BaseProject.Application.Features.Commands.Definitions.Company.Update
{
    public class UpdateCompanyRequest : IRequest<UpdateCompanyResponse>
    {
        public string Id { get; set; }

        public List<FileOptionDTO>? FileOptions { get; set; }

        public string Name { get; set; }

        public string AuthorizedFullName { get; set; }

        public string? PhoneNumber { get; set; }

        public string? FaxNo { get; set; }

        public string? Email { get; set; }

        public string? WebAddress { get; set; }

        public string? TaxOffice { get; set; }

        public string? TaxNo { get; set; }

        public string? TradeRegisterNo { get; set; }

        public string? SocialSecurityNo { get; set; }

        public string? MersisNo { get; set; }

        public List<CompanyLicenseCreateVM> CompanyLicenses { get; set; }

        public List<CompanyAddressCreateVM>? CompanyAddresses { get; set; }
    }
}