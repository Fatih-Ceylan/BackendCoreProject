namespace Card.Application.Features.Commands.Definitions.Cargo.Update
{
    public class UpdateCargoResponse
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public int TaxRate { get; set; }
        public decimal CargoPrice { get; set; }
        public string CompanyId { get; set; }
        public string BranchId { get; set; }
        public string Message { get; set; }
    }
}
