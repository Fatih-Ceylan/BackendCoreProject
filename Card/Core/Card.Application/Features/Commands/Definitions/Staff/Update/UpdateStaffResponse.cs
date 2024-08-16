namespace Card.Application.Features.Commands.Definitions.Staff.Update
{
    public class UpdateStaffResponse
    {
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Title { get; set; }
        public string? ProfilePicturePath { get; set; }
        public string? Description { get; set; }
        public string Message { get; set; }
        public string CompanyId { get; set; }
        public string BranchId { get; set; }
        public string PhoneNumber { get; set; }
    }
}
