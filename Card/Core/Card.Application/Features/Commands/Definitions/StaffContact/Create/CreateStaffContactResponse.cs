namespace Card.Application.Features.Commands.Definitions.StaffContact.Create
{
    public class CreateStaffContactResponse
    {
        public string Id { get; set; }
        public string StaffId { get; set; }
        public string ContactId { get; set; }
        public string ContactName { get; set; }
        public string CompanyId { get; set; }
        public string BranchId { get; set; }
        public string Message { get; set; }
    }
}
