namespace GCharge.Application.DTOs.Identity.AppUser
{
    public class CreateUserResponseDTO
    {
        public string Id { get; set; }
        
        public string FullName { get; set; }

        public string Email { get; set; }

        public string? PhoneNumber { get; set; }

        public bool Succeed { get; set; }

        public string Message { get; set; }
    }
}