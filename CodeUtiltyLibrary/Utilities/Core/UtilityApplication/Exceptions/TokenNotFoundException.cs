using System.Runtime.Serialization;

namespace Utilities.Core.UtilityApplication.Exceptions
{
    public class TokenNotFoundException : Exception
    {
        public TokenNotFoundException() : base("Token Not Found!")
        {
        }

        public TokenNotFoundException(string? message) : base(message)
        {
        }

        public TokenNotFoundException(string? message, Exception? innerException) : base(message, innerException)
        {
        }

        protected TokenNotFoundException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
