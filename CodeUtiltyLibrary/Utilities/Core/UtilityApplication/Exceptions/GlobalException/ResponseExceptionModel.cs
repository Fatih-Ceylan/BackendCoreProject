using Newtonsoft.Json;

namespace Utilities.Core.UtilityApplication.Exceptions.GlobalException
{
    public class ResponseExceptionModel
    {
        public int StatusCode { get; }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string Message { get; }

        public ResponseExceptionModel(string message, int statusCode = 500)
        {
            StatusCode = statusCode;
            Message = message;
        }

    }
}
