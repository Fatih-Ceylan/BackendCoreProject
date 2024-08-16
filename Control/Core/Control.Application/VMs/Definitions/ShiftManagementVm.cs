using BaseProject.Domain.Entities.Definitions;
using Utilities.Core.UtilityApplication.VMs;

namespace GControl.Application.VMs.Definitions
{
    public class ShiftManagementVM : BaseVM
    {
        public string Title { get; set; }
        public bool Monday { get; set; }
        public bool Tuesday { get; set; }
        public bool Wednesday { get; set; }
        public bool Thursday { get; set; }
        public bool Friday { get; set; }
        public bool Saturday { get; set; }
        public bool Sunday { get; set; }
        public string? CompanyId { get; set; }
        public Company Company { get; set; }
        public DateTime? ShiftStartDate { get; set; }
        public DateTime ShiftEndDate { get; set; }
    }
}
