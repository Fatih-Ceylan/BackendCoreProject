using Utilities.Core.UtilityDomain.Entities;

namespace BaseProject.Domain.Entities.GCrm.Definitions.CustomerManagement.Customers
{
    //Müşteri Türü
    public class CustomerKind : BaseEntity
    {
        public string Name { get; set; }

        public ICollection<Customer> Customers { get; set; }
    }
}