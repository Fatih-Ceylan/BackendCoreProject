namespace BaseProject.Application.DTOs.Definitions.Branch
{
    public class BranchDTO
    {
        public string Id { get; set; }

        public string Name { get; set; }

        public string? CompanyId { get; set; }

        public string? CountryId { get; set; }

        public string CountryName { get; set; }

        public string CompanyName { get; set; }

        public string FullAddress { get; set; }

        public string? CityId { get; set; }

        public string CityName { get; set; }

        public string? DistrictId { get; set; }

        public string DistrictName { get; set; }

        public string TaxNo { get; set; }

        public string TaxOffice { get; set; }

    }
}
