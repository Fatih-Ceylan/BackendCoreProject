using Utilities.Core.UtilityDomain.Entities.Files;

namespace Platform.Domain.Entities.Definitions.Files
{
    public class CompanyFile : AppFile
    {
        public ICollection<Company> Companies { get; set; }
    }
}