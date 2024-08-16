namespace Platform.Application.DTOs.Identity.AppUser
{
    public class UpdateUserRequestDTO
    {
        public string Id { get; set; }

        public string UserName { get; set; }

        public string FullName { get; set; }

        public string Email { get; set; }

        public string SecurityStamp { get; set; }

        public bool IsDeleted { get; set; }

        public string? ProfileImagePath { get; set; }
    }
}