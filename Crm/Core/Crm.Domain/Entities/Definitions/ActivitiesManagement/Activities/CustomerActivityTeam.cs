using GCrm.Domain.Entities.Definitions.ActivitiesManagement.Activities.Files;
using Utilities.Core.UtilityDomain.Entities;

namespace GCrm.Domain.Entities.Definitions.ActivitiesManagement.Activities
{
    public class CustomerActivityTeam : BaseEntity
    {
        public string Name { get; set; }

        public ICollection<CustomerActivityTeam>  CustomerActivityTeams { get; set; }
    }
}
