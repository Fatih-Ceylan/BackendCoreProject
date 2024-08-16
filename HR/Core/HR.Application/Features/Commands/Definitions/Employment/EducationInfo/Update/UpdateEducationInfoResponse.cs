namespace HR.Application.Features.Commands.Definitions.Employment.EducationInfo.Update
{
    public class UpdateEducationInfoResponse
    {
        public string Id { get; set; }

        public string? Name { get; set; }

        public string? Description { get; set; }

        public DateTime? StartDate { get; set; }

        public DateTime? EndDate { get; set; }

        public string Message { get; set; }
    }
}
