namespace BaseProject.Domain.Entities.HR.Recruitment.Recruit
{
    public class RecruitmentProcessStep : B_BaseEntity
    {
        public Guid RecruitmentProcessId { get; set; }

        public Guid RecruitmentStepId { get; set; }

        public string Status { get; set; }

        public int Priority { get; set; }

        public RecruitmentProcess RecruitmentProcess { get; set; }

        public RecruitmentStep RecruitmentStep { get; set; }
    }
}
