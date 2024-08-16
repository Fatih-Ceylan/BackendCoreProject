namespace GCrm.Application.Features.Commands.Definitions.CustomerOffer.Create
{
    public class CreateCustomerOfferResponse
    {
        public string Id { get; set; }
        public string OfferNo { get; set; }
        public string OfferSubject { get; set; }
        public DateTime OfferDate { get; set; }
        public int TotalAmount { get; set; }
        public string OfferStatus { get; set; }
        public string CreatedUser { get; set; }
        public string Message { get; set; }
    }
}
