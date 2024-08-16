using Utilities.Core.UtilityDomain.Entities.Files;

namespace GCrm.Domain.Entities.Definitions.CustomerManagement.Customers.Files
{
    public class CustomerFile : AppFile
    {
        public List<Customer> Customer { get; set; }
    }
}
