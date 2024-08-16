using Utilities.Core.UtilityApplication.VMs;

namespace Card.Application.VMs
{
    public class AddressVM : BaseVM
    {
        public string AddressLine { get; set; }
        public string AddressType { get; set; }
        public string CountryId { get; set; }
        public string CountryName { get; set; }
        public string CityId { get; set; }
        public string CityName { get; set; }
        public string DistrictId { get; set; }
        public string DistrictName { get; set; }
        public string CompanyId { get; set; }
        public string BranchId { get; set; }
        public string? CompanyName { get; set; }
        public string? BranchName { get; set; }
    }
}
