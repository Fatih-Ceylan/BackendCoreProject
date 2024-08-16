namespace Utilities.Core.UtilityApplication.Exceptions
{
    public class TokenExpiryDateException : Exception
    {
        public TokenExpiryDateException() : base("Token Expired")
        {
        }

        public TokenExpiryDateException(string? message) : base(message)
        {
        }

        public TokenExpiryDateException(string? message, Exception? innerException) : base(message, innerException)
        {
        }
    }
}