using BaseProject.Domain.Entities.HR.Enums;
using MediatR;

namespace HR.Application.Features.Commands.Definitions.Recruitment.Jobs.JobAdvert.Update
{
    public class UpdateJobAdvertRequest : IRequest<UpdateJobAdvertResponse>
    {
        public string Id { get; set; }

        public string? JobTitle { get; set; }

        public string? Code { get; set; }

        public string? CompanyName { get; set; }

        public string? Description { get; set; }

        public int? NumberOfVacancy { get; set; }

        public DateTime? PostingDate { get; set; }

        public string? AppellationId { get; set; }

        public List<WorkLocationEnum>? WorkLocations { get; set; }
    }
}
