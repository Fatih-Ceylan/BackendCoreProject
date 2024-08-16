using Utilities.Core.UtilityDomain.Entities.Files;

namespace BaseProject.Domain.Entities.GCrm.Definitions.CustomerManagement.Customers.Files
{
    public class CustomerFile : AppFile
    {
        public List<Customer> Customer { get; set; }
    }
}
