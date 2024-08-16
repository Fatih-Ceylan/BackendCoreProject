namespace NLLogistics.Application.Features.Commands.Definitions.Airline.Update
{
    public class UpdateAirlineResponse
    {
        public string Id { get; set; }

        public string Code { get; set; }

        public string Name { get; set; }

        public int? CountryId { get; set; }

        public string Message { get; set; }

    }
}
