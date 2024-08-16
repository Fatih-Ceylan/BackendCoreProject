using BaseProject.Domain.Entities.HR.Recruitment.Applications;

namespace BaseProject.Domain.Entities.HR.Recruitment.Recruit
{
    public class Recruiter : B_BaseEntity
    {
        public string Code { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public ICollection<JobApplication> JobApplications { get; set; }

        public ICollection<Notes> Notes { get; set; }
    }
}