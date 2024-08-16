namespace BaseProject.Domain.Entities.HR.Recruitment.Applications
{
    public class JobApplicationStatusHistory : B_BaseEntity
    {

        public Guid JobApplicationStatusId { get; set; }

        public DateTime StatusTime { get; set; }

        public JobApplicationStatus JobApplicationStatus { get; set; }
    }
}
