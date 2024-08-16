namespace BaseProject.Application.Features.Commands.Definitions.City.Create
{
    public class CreateCityResponse
    {
        public int Id { get; set; }

        public int CountryId { get; set; }

        public string Name { get; set; }

        public string Message { get; set; }
    }
}