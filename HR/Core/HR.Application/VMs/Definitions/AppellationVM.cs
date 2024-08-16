using Utilities.Core.UtilityApplication.VMs;

namespace HR.Application.VMs.Definitions
{
    public class AppellationVM : BaseVM
    {
        public string Code { get; set; }

        public string Name { get; set; }

        public string? MainAppellationId { get; set; }
    }
}
