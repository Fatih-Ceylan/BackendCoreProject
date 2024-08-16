namespace BaseProject.Domain.Entities.HR.Recruitment.Applications
{
    public class JobApplicationStatus : B_BaseEntity
    {
        public string Name { get; set; }

        public ICollection<JobApplication> JobApplications { get; set; }

        public ICollection<JobApplicationStatusHistory> JobApplicationStatusHistories { get; set; }

    }
}
