namespace Utilities.Core.UtilityApplication.DTOs.Identity.Auth.Login
{
    public class LoginResponseDTO
    {
        public TokenDTO Token { get; set; }

        public string Message { get; set; } = "Authentication Succeed";
    }
}
