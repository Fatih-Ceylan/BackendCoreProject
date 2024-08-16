namespace Card.Application.Features.Commands.Definitions.Address.Create
{
    public class CreateAddressResponse
    {
        public string Id { get; set; }
        public string AddressLine { get; set; }
        public string AddressType { get; set; }
        public string StaffId { get; set; }
        public string CompanyId { get; set; } 
        public string BranchId { get; set; }
        public string CountryId { get; set; }
        public string CityId { get; set; }
        public string DistrictId { get; set; }
        public string Message { get; set; }
        public string PhoneNumber { get; set; }
    }
}
