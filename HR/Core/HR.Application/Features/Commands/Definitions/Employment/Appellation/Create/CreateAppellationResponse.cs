namespace HR.Application.Features.Commands.Definitions.Employment.Appellation.Create
{
    public class CreateAppellationResponse
    {
        public string Id { get; set; }

        public string Code { get; set; }

        public string Name { get; set; }

        public string? MainAppellationId { get; set; }

        public string Message { get; set; }
    }
}
