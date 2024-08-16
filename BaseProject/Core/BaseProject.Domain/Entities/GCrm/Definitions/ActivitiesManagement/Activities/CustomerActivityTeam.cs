using Utilities.Core.UtilityDomain.Entities;

namespace BaseProject.Domain.Entities.GCrm.Definitions.ActivitiesManagement.Activities
{
    public class CustomerActivityTeam : BaseEntity
    {
        public string Name { get; set; }

        public ICollection<CustomerActivityTeam> CustomerActivityTeams { get; set; }
    }
}
