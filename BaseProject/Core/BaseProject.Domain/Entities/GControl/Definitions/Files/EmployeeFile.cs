using Utilities.Core.UtilityDomain.Entities.Files;

namespace BaseProject.Domain.Entities.GControl.Definitions.Files
{
    public class EmployeeFile : AppFile
    {
        public ICollection<Employee> Employees { get; set; }
    }
}
