using Utilities.Core.UtilityDomain.Entities.Files;

namespace Platform.Domain.Entities.Definitions.Files
{
    public class GModuleFile : AppFile
    {
        public ICollection<GModule> GModules { get; set; }
    }
}
