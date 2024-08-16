namespace Utilities.Core.UtilityApplication.Exceptions
{
    public class NotFoundUserEcxeption : Exception
    {
        public NotFoundUserEcxeption() : base("Invalid User!")
        {
        }

        public NotFoundUserEcxeption(string? message) : base(message)
        {
        }

        public NotFoundUserEcxeption(string? message, Exception? innerException) : base(message, innerException)
        {
        }
    }
}
