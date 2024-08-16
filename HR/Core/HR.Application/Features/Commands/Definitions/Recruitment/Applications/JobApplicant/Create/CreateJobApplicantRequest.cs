using MediatR;

namespace HR.Application.Features.Commands.Definitions.Recruitment.Applications.JobApplicant.Create
{
    public class CreateJobApplicantRequest : IRequest<CreateJobApplicantResponse>
    {
        public string Code { get; set; }

        public string FirstName { get; set; }

        public string? LastName { get; set; }

        public string? Phone { get; set; }

        public string? Email { get; set; }

        public string? Summary { get; set; }

        public string? JobAdvertId { get; set; }

        public string? JobApplicantDocumentId { get; set; }
    }
}
