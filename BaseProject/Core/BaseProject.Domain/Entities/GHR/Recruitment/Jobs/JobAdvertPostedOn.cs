namespace BaseProject.Domain.Entities.HR.Recruitment.Jobs
{
    public class JobAdvertPostedOn : B_BaseEntity
    {
        public Guid JobAdvertId { get; set; }

        public string Description { get; set; }

        public string PostedLink { get; set; }

        public JobAdvert JobAdvert { get; set; }
    }
}
