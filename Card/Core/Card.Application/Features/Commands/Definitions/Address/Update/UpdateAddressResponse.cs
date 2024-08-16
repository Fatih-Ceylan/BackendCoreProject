namespace Card.Application.Features.Commands.Definitions.Address.Update
{
    public class UpdateAddressResponse
    {
        public string Id { get; set; }
        public string AddressLine { get; set; }
        public string AddressType { get; set; }
        public string StaffId { get; set; }
        public string CompanyId { get; set; }
        public string BranchId { get; set; }
        public string Message { get; set; }
    }
}
