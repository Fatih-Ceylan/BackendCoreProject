namespace GCharge.Application.DTOs.Identity.AppUser
{
    public class UpdateUserRequestDTO
    {
        public string Id { get; set; }

        public string? ProfileImagePath { get; set; }

        public string FullName { get; set; }

        public string UserName { get; set; }

        public string Email { get; set; }

    }
}