using BaseProject.Domain.Entities.HR.Files;
using BaseProject.Domain.Entities.HR.Recruitment.Jobs;
using BaseProject.Domain.Entities.HR.Recruitment.Recruit;

namespace BaseProject.Domain.Entities.HR.Recruitment.Applications
{
    public class JobApplicant : B_BaseEntity
    {
        public string Code { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Phone { get; set; }

        public string Email { get; set; }

        public string Summary { get; set; }

        public Guid? JobAdvertId { get; set; }

        public Guid? JobApplicantDocumentId { get; set; }

        public JobAdvert JobAdvert { get; set; }

        public JobApplicantDocument JobApplicantDocument { get; set; }

        public ICollection<Notes> Notes { get; set; }

        public ICollection<JobApplication> JobApplications { get; set; }
    }
}
