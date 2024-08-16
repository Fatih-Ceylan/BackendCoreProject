using MediatR;

namespace HR.Application.Features.Commands.Definitions.Recruitment.Applications.JobApplication.Create
{
    public class CreateJobApplicationRequest :IRequest<CreateJobApplicationResponse>
    {
        public string? JobApplicantId { get; set; }

        public string? RecruiterId { get; set; }

        public string? RecruitmentProcessId { get; set; }

        public string? JobApplicationStatusId { get; set; }
        
        public string? JobAdvertId { get; set; }

        //public List<JobApplicationStatusHistoryVM>? JobApplicationStatusHistories { get; set; }

        public DateTime? ApplicationDate { get; set; }

        public string? Details { get; set; }

        public string? Notes { get; set; }
    }
}
