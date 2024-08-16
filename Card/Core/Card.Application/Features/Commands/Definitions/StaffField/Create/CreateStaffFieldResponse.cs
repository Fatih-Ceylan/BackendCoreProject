namespace Card.Application.Features.Commands.Definitions.StaffField.Create
{
    public class CreateStaffFieldResponse
    {
        public string Id { get; set; }
        public string FieldName { get; set; }
        public int RowNumber { get; set; }
        public string StaffId { get; set; }
        public string CompanyId { get; set; }
        public string BranchId { get; set; }
        public string Message { get; set; }
    }
}
