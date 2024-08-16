using System.ComponentModel;

namespace Utilities.Core.UtilityApplication.Enums
{
    public enum CommandResponseMessage
    {
        [Description("Added Success")]
        AddedSuccess,
        [Description("Added Error!")]
        AddedError,
        [Description("Updated Success")]
        UpdatedSuccess,
        [Description("Updated Error!")]
        UpdatedError,
        [Description("Deleted Success")]
        DeletedSuccess,
        [Description("Deleted Error!")]
        DeletedError,
        [Description("VerificationCodeUnmatched")]
        VerificationCodeUnmatched,
        [Description("TokenNotMatchedError")]
        TokenNotMatchedError,
        [Description("SessionExpired")]
        SessionExpired,
        [Description("UserNotFound")]
        UserNotFound,
        [Description("Success")]
        Success,
        [Description("EmailNotFound")]
        EmailNotFound,
        [Description("PasswordNotMatched")]
        PasswordNotMatched,
        [Description("TokenNotValid")]
        TokenNotValid,
        [Description("NotFound")]
        NotFound,
        [Description("InvalidId")]
        InvalidId,
        [Description("LoginSuccess")]
        LoginSuccess,
    }
}