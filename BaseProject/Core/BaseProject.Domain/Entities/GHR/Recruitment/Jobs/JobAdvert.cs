using BaseProject.Domain.Entities.HR.Employment;
using BaseProject.Domain.Entities.HR.Enums;
using BaseProject.Domain.Entities.HR.Recruitment.Applications;
using System.ComponentModel.DataAnnotations.Schema;

namespace BaseProject.Domain.Entities.HR.Recruitment.Jobs
{
    public class JobAdvert : B_BaseEntity
    {
        public string JobTitle { get; set; }

        public string Code { get; set; }

        public string CompanyName { get; set; }

        public string Description { get; set; }

        public int NumberOfVacancy { get; set; }

        public DateTime? PostingDate { get; set; }

        public Guid AppellationId { get; set; }

        public string WorkLocationString { get; set; }

        [NotMapped]
        public List<WorkLocationEnum> WorkLocations
        {
            get
            {
                if (string.IsNullOrWhiteSpace(WorkLocationString))
                    return new List<WorkLocationEnum>();

                return WorkLocationString
                    .Split(',')
                    .Select(e => (WorkLocationEnum)Enum.Parse(typeof(WorkLocationEnum), e, true))
                    .ToList();
            }
            set
            {
                WorkLocationString = string.Join(",", value.Select(e => nameof(e)));
            }
        }

        public Appellation Appellation { get; set; }

        public ICollection<Location> Locations { get; set; }

        public ICollection<JobApplicant> JobApplicants { get; set; }

        public ICollection<JobApplication> JobApplications { get; set; }

        public ICollection<JobAdvertPostedOn> jobAdvertPostedOn { get; set; }
    }
}
