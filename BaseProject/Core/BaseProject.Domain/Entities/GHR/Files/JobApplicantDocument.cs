using BaseProject.Domain.Entities.HR.Recruitment.Applications;
using Utilities.Core.UtilityDomain.Entities.Files;

namespace BaseProject.Domain.Entities.HR.Files
{
    public class JobApplicantDocument : AppFile
    {
        public ICollection<JobApplicant> JobApplicants { get; set; }
    }
}
