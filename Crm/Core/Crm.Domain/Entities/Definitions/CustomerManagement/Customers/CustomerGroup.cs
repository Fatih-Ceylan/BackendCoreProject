using Utilities.Core.UtilityDomain.Entities;

namespace GCrm.Domain.Entities.Definitions.CustomerManagement.Customers
{
    public class CustomerGroup : BaseEntity
    {
        public string CustomerGroupName { get; set; }
        public string CustomerGroupType { get; set; }
        public ICollection<Customer> Customers  { get; set; } 
    }
}
