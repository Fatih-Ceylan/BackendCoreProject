namespace Platform.Application.DTOs.Identity.AppUser
{
    public class CreateUserRequestDTO
    {
        public string UserName { get; set; }

        public string FullName { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }

        public string PasswordConfirm { get; set; }

        public string? ProfileImagePath { get; set; }
    }
}