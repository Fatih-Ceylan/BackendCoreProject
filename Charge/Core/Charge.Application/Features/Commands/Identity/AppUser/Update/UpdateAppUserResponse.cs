namespace GCharge.Application.Features.Commands.Identity.AppUser.Update
{
    public class UpdateAppUserResponse
    {
        public string Id { get; set; }

        public string? ProfileImagePath { get; set; }

        public string FullName { get; set; }

        public string UserName { get; set; }

        public string Email { get; set; }

        public bool Succeed { get; set; }

        public string Message { get; set; }
    }
}