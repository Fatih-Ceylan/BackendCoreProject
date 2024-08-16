using Utilities.Core.UtilityDomain.Entities;

namespace GCrm.Domain.Entities.Definitions.CustomerManagement.Customers
{
    public class CustomerStatus : BaseEntity
    {
        public string Name { get; set; }

        public ICollection<Customer> Customers { get; set; }
    }
}
