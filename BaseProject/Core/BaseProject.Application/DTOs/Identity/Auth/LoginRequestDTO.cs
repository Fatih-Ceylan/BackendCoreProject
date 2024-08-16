namespace BaseProject.Application.DTOs.Identity.Auth
{
    public class LoginRequestDTO
    {
        public string UserNameOrEmail { get; set; }
        
        public string Password { get; set; }

        public string UrlPath { get; set; }

        public string MasterCompanyIdFromPlatform { get; set; }
    }
}