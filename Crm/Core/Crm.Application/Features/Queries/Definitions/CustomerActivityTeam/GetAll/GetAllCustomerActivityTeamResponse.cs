using GCrm.Application.VMs.Definitions;

namespace GCrm.Application.Features.Queries.Definitions.CustomerActivityTeam.GetAll
{
    public  class GetAllCustomerActivityTeamResponse
    {
        public int TotalCount { get; set; }

        public List<CustomerActivityTeamVM> customerActivityTeams { get; set; }
    }
}
