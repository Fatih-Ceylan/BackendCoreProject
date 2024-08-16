using GCrm.Domain.Entities.CustomerManagement;
using Utilities.Core.UtilityDomain.Entities;

namespace GCrm.Domain.Entities.Definitions.Customers
{
    public  class CustomerRepresentative : BaseEntity
    {
        public string  Name { get; set; }      
        public Customer Customer { get; set; }

    }
}
