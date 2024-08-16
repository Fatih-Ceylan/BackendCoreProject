using BaseProject.Domain.Entities.HR.Recruitment.Jobs;
using BaseProject.Domain.Entities.HR.Recruitment.Recruit;

namespace BaseProject.Domain.Entities.HR.Recruitment.Applications
{
    public class JobApplication : B_BaseEntity
    {
        public Guid JobApplicantId { get; set; }

        public Guid? RecruiterId { get; set; }

        public Guid? RecruitmentProcessId { get; set; }

        public Guid JobApplicationStatusId { get; set; }

        public Guid? JobAdvertId { get; set; }

        public JobApplicant JobApplicant { get; set; }

        public Recruiter Recruiter { get; set; }

        public RecruitmentProcess RecruitmentProcess { get; set; }

        public JobApplicationStatus JobApplicationStatus { get; set; }

        public JobAdvert JobAdvert { get; set; }

        public DateTime? ApplicationDate { get; set; }

        public string? Details { get; set; }

        public string? Notes { get; set; }
    }
}
