using Utilities.Core.UtilityDomain.Entities;

namespace GCrm.Application.VMs.Definitions
{
    public class CustomerContactListCreateVM : BaseEntity
    {
        public string? Id { get; set; }
        public string? Name { get; set; }
        public string? Title { get; set; }
    }
}
