using BaseProject.Domain.Entities.HR.Recruitment.Applications;

namespace BaseProject.Domain.Entities.HR.Recruitment.Recruit
{
    public class Notes : B_BaseEntity
    {
        public Guid ApplicantId { get; set; }

        public Guid RecruiterId { get; set; }

        public JobApplicant Applicant { get; set; }

        public Recruiter Recruiter { get; set; }

        public string NoteText { get; set; }
    }
}
