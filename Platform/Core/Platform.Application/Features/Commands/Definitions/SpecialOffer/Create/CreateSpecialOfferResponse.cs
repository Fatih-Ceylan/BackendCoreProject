namespace Platform.Application.Features.Commands.Definitions.SpecialOffer.Create
{
    public class CreateSpecialOfferResponse
    {
        public string Id { get; set; }

        public string CompanyId { get; set; }

        public string GModuleId { get; set; }

        public decimal DiscountRate { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public string? Description { get; set; }

        public string Message { get; set; }

    }
}
