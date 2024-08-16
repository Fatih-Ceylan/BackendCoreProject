using Utilities.Core.UtilityDomain.Entities.Files;

namespace BaseProject.Domain.Entities.Identity.File
{
    public class AppUserFile: AppFile
    {
        public ICollection<AppUser> AppUsers { get; set; }
    }
}
