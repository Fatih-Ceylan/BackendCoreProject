using Utilities.Core.UtilityDomain.Entities;

namespace GCrm.Domain.Entities.Definitions.ActivitiesManagement.Activities
{
    public class CustomerActivityKind : BaseEntity
    {
        public string Name { get; set; }

        public ICollection<CustomerActivity> CustomerActivities { get; set; }
    }
}
