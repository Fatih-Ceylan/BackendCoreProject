using Utilities.Core.UtilityApplication.VMs;

namespace HR.Application.Features.Commands.Definitions.Recruitment.Applications.JobApplicationStatusHistory.VM
{
    public class CreateJobAppStatHistoryVM : BaseVM
    {
        public string JobApplicationId { get; set; }

        public string JobApplicationStatusId { get; set; }

        public DateTime StatusTime { get; set; }
    }
}
