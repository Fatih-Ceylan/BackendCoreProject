using Utilities.Core.UtilityDomain.Entities;

namespace BaseProject.Domain.Entities.GCrm.Definitions.ActivitiesManagement.Activities
{
    public class CustomerActivitySubject : BaseEntity
    {
        public string Name { get; set; }

        public ICollection<CustomerActivity> CustomerActivity { get; set; }
    }
}
