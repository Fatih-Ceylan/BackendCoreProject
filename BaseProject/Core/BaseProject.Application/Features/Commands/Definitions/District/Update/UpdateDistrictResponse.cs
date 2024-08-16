namespace BaseProject.Application.Features.Commands.Definitions.District.Update
{
    public class UpdateDistrictResponse
    {
        public int Id { get; set; }

        public int CountryId { get; set; }

        public int CityId { get; set; }

        public string Name { get; set; }

        public string Message { get; set; }

    }
}