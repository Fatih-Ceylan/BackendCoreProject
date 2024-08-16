using Utilities.Core.UtilityApplication.VMs;

namespace GControl.Application.VMs.Definitions
{
    public class LoginVM : BaseVM
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Token { get; set; }
        public string Message { get; set; }
    }
}
