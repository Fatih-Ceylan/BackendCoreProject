namespace NLLogistics.Application.Features.Commands.Definitions.Airport.Create
{
    public class CreateAirportResponse
    {
        public string Id { get; set; }

        public string Code { get; set; }

        public string Name { get; set; }

        public int? CountryId { get; set; }

        public string Message { get; set; }
    }
}
