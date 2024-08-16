using Utilities.Core.UtilityDomain.Entities.Files;

namespace BaseProject.Domain.Entities.Card.Definitions.Files
{
    public class StaffFile : AppFile
    {
        public ICollection<Staff> Staffs { get; set; }
    }
}
