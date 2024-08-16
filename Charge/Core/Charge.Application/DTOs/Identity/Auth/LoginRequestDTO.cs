namespace GCharge.Application.DTOs.Identity.Auth
{
    public class LoginRequestDTO
    {
        public string UserNameOrEmail { get; set; }

        public string Password { get; set; }
    }
}