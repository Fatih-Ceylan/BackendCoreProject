using Utilities.Core.UtilityDomain.Entities;

namespace BaseProject.Domain.Entities.Card.Definitions
{
    public class Field:BaseEntity
    {
        public string Name { get; set; } 
        public ICollection<StaffField> StaffFields { get; set; }
    }
}
