using BaseProject.Application.VMs.Definitions.Country;

namespace BaseProject.Application.Features.Queries.Definitions.Country.GetAll
{
    public class GetAllCountryResponse
    {
        public int TotalCount { get; set; }

        public List<CountryVM> Countries { get; set; }
    }
}
