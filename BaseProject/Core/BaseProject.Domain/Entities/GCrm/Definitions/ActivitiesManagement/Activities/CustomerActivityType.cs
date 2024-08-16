using Utilities.Core.UtilityDomain.Entities;

namespace BaseProject.Domain.Entities.GCrm.Definitions.ActivitiesManagement.Activities
{
    public class CustomerActivityType : BaseEntity
    {
        public string Name { get; set; }

        public ICollection<CustomerActivity> CustomerActivities { get; set; }
    }
}
