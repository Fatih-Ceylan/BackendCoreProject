namespace BaseProject.Domain.Entities.Definitions
{
    public class CompanyAddress : B_BaseEntity
    {
        public Guid CompanyId { get; set; }

        public Guid AddressTypeId { get; set; }

        public string? FullAddress { get; set; }

        public string? PostalCode { get; set; }

        public int? CountryId { get; set; }

        public int? CityId { get; set; }

        public int? DistrictId { get; set; }

        public Company Company { get; set; }

        public AddressType AddressType { get; set; }

        public District? District { get; set; }

    }
}