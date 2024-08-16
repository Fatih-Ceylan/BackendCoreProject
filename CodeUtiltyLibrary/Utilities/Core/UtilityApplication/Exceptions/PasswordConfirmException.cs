namespace Utilities.Core.UtilityApplication.Exceptions
{
    public class PasswordConfirmException : Exception
    {
        public PasswordConfirmException() : base("Password not matched!")
        {
        }

        public PasswordConfirmException(string? message) : base(message)
        {
        }

        public PasswordConfirmException(string? message, Exception? innerException) : base(message, innerException)
        {
        }
    }
}
