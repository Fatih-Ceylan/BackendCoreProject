using Utilities.Core.UtilityDomain.Entities;

namespace BaseProject.Domain.Entities.GCrm.Definitions.CustomerManagement.Customers
{
    public class CustomerCategory : BaseEntity
    {
        public string Name { get; set; }
        public ICollection<Customer> Customers { get; set; }
    }
}