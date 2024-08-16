namespace Platform.Application.VMs.Definitions.SpecialOffer
{
    public class SpecialOfferInLicenseDetailVM
    {
        public string Id { get; set; }

        public string? Description { get; set; }

        public decimal DiscountRate { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

    }
}