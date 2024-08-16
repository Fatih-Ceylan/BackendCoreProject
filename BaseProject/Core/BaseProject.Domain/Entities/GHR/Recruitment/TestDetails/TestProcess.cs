using BaseProject.Domain.Entities.HR.Recruitment.Applications;

namespace BaseProject.Domain.Entities.HR.Recruitment.TestDetails
{
    public class TestProcess : B_BaseEntity
    {
        public string ProcessName { get; set; }

        public ICollection<JobApplication> JobApplications { get; set; }
    }
}
