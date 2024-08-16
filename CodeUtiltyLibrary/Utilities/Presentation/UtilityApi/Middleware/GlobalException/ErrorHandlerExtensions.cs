using Microsoft.AspNetCore.Builder;

namespace Utilities.Presentation.UtilityApi.Middleware.GlobalException
{
    public static class ErrorHandlerExtensions
    {
        public static IApplicationBuilder UseErrorWrappingMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<ErrorHandler>();
        }
    }
}
