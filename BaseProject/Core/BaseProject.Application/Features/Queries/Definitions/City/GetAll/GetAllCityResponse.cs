using BaseProject.Application.VMs.Definitions.City;

namespace BaseProject.Application.Features.Queries.Definitions.City.GetAll
{
    public class GetAllCityResponse
    {
        public int TotalCount { get; set; }

        public List<CityVM> Cities { get; set; }
    }
}