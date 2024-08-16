using Utilities.Core.UtilityApplication.VMs;

namespace BaseProject.Application.VMs.Definitions.Branch
{
    public class BranchVM : BaseVM
    {
        public string CompanyId { get; set; }

        public string CompanyName { get; set; }

        public string Code { get; set; }

        public string Name { get; set; }

        public string? AuthorizedFullName { get; set; }

        public string? FullAddress { get; set; }

        public string? PostalCode { get; set; }

        public string? PhoneNumber { get; set; }

        public string? Email { get; set; }

        public int? CountryId { get; set; }

        public string? CountryName { get; set; }

        public int? CityId { get; set; }

        public string? CityName { get; set; }

        public int? DistrictId { get; set; }

        public string? DistrictName { get; set; }
    }
}