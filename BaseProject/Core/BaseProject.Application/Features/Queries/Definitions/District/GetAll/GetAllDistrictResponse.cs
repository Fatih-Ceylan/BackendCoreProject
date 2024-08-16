using BaseProject.Application.VMs.Definitions.District;

namespace BaseProject.Application.Features.Queries.Definitions.District.GetAll
{
    public class GetAllDistrictResponse
    {
        public int TotalCount { get; set; }

        public List<DistrictVM> Districts { get; set; }
    }
}