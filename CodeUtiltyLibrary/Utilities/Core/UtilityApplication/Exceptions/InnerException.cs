namespace Utilities.Core.UtilityApplication.Exceptions
{
    public static class InnerException
    {
        public static string GetInnerException(Exception ex)
        {
            return ex.InnerException != null ? ex.InnerException.Message : ex.Message;
        }
        public static Exception GetOriginalException(this Exception ex)
        {
            if (ex.InnerException == null) return ex;

            return ex.InnerException.GetOriginalException();
        }
    }
 
}
