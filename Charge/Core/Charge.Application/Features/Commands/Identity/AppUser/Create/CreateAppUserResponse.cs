namespace GCharge.Application.Features.Commands.Identity.AppUser.Create
{
    public class CreateAppUserResponse
    {
        public string Id { get; set; }

        public string FullName { get; set; }

        public string Email { get; set; }

        public string? PhoneNumber { get; set; }

        public bool Succeed { get; set; }

        public List<string> Messages { get; set; }

    }
}