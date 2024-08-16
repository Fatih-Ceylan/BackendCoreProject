namespace Card.Application.VMs
{
    public class CreateAddressVM
    {
        public string AddressLine { get; set; }
        public string AddressType { get; set; }
        public int CountryId { get; set; }
        public int CityId { get; set; }
        public int DistrictId { get; set; }
        public string CompanyId { get; set; }
        public string BranchId { get; set; }
    }
}
