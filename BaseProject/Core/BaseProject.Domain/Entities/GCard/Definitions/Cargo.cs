using BaseProject.Domain.Entities.Definitions;
using Utilities.Core.UtilityDomain.Entities;

namespace BaseProject.Domain.Entities.Card.Definitions
{
    public class Cargo : BaseEntity
    {
        public string Name { get; set; }
        public int TaxRate { get; set; }
        public decimal CargoPrice { get; set; }
        public Guid? CompanyId { get; set; } 
        public Guid? BranchId { get; set; }
        public Branch Branch { get; set; }
    }
}
