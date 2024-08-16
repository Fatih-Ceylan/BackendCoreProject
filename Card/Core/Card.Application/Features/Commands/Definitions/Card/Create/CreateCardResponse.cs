namespace Card.Application.Features.Commands.Definitions.Card.Create
{
    public class CreateCardResponse
    {
        public string Id { get; set; }
        public decimal Price { get; set; }
        public int TaxRate { get; set; }
        public string CompanyId { get; set; }
        public string BranchId { get; set; }
        public string Message { get; set; }
    }
}
