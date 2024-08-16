namespace Card.Application.Features.Commands.Definitions.Iban.Create
{
    public class CreateIbanResponse
    {
        public string Id { get; set; }
        public string IbanNo { get; set; }
        public string StaffId { get; set; }
        public string CompanyId { get; set; }
        public string BranchId { get; set; }
        public string Message { get; set; }
    }
}
