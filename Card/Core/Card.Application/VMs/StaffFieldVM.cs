namespace Card.Application.VMs
{
    public class StaffFieldVM
    {
        public string Id { get; set; }
        public int RowNumber { get; set; }
        public string StaffId { get; set; } 
        public string? FieldName { get; set; }
        public string FieldId { get; set; }
        public string? CompanyId { get; set; }
        public string? BranchId { get; set; }
        public string? CompanyName { get; set; }
        public string? BranchName { get; set; }
    }
}
