namespace Card.Application.Features.Commands.Definitions.Staff.Create
{
    public class CreateStaffResponse
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Title { get; set; } 
        public string? Description { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string? Token { get; set; }
        public string Message { get; set; }
        public string PhoneNumber { get; set; }
        public string CompanyId { get; set; }
        public string BranchId { get; set; }
    }
}
