namespace HR.Application.Features.Commands.Definitions.Employment.Appellation.Update
{
    public class UpdateAppellationResponse
    {
        public string Id { get; set; }

        public int? Code { get; set; }

        public string? Name { get; set; }

        public string? MainAppellationId { get; set; }

        public string Message { get; set; }
    }
}
