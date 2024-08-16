namespace Card.Application.Features.Queries.Definitions.Address.GetUserAddress
{
    public class GetUserAddressResponse
    {
        public string Id { get; set; }
        public string  FullAddress { get; set; }
        public string CityId { get; set; }
        public string DistrictId { get; set; } 
        public string FullName { get; set; }
        public string PhoneNumber { get; set; }
        public string BaseProjectCompanyId { get; set; }
        public string BaseProjectCompanyName { get; set; }
        public string BaseProjectBranchId { get; set; }
        public string BaseProjectBranchName { get; set; }
    }
}
