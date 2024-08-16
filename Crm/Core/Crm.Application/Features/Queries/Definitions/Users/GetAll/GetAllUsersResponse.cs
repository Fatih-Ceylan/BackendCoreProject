using GCrm.Application.VMs.Definitions;

namespace GCrm.Application.Features.Queries.Definitions.Users.GetAll
{
    public  class GetAllUsersResponse
    {
        public int TotalCount { get; set; }
        public List<UsersVM> Users  { get; set; }
    }
}
