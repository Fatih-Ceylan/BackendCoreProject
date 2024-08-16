namespace BaseProject.Domain.Entities.HR.Recruitment.Recruit
{
    public class RecruitmentProcess : B_BaseEntity
    {
        public string Code { get; set; }

        public string Description { get; set; }

        public Guid RecruiterId { get; set; }

        public ICollection<RecruitmentProcessStep> RecruitmentProcessStep { get; set; }
    }
}
