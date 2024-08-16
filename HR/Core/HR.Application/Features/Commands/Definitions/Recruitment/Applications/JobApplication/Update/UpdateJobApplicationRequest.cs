using MediatR;

namespace HR.Application.Features.Commands.Definitions.Recruitment.Applications.JobApplication.Update
{
    public class UpdateJobApplicationRequest : IRequest<UpdateJobApplicationResponse>
    {
        public string Id { get; set; }

        public string? JobApplicantId { get; set; }

        public string? JobApplicantName { get; set; }

        public string? RecruiterId { get; set; }

        public string? RecruiterName { get; set; }

        public string? RecruitmentProcessId { get; set; }

        public string? RecruitmentProcessName { get; set; }

        public string? JobApplicationStatusId { get; set; }

        public string? JobApplicationStatusName { get; set; }

        public string? JobAdvertId { get; set; }

        public string? JobAdvertName { get; set; }

        public DateTime? ApplicationDate { get; set; }

        public string? Details { get; set; }

        public string? Notes { get; set; }

    }
}
