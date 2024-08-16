namespace Utilities.Core.UtilityApplication.DTOs.Identity
{
    public class TokenDTO
    {
        public string AccessToken { get; set; }
        public DateTime ExpiryDate { get; set; }
        public string RefreshToken { get; set; }
    }
}
