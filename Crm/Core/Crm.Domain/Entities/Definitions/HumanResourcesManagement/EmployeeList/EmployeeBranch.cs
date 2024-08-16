using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utilities.Core.UtilityDomain.Entities;

namespace GCrm.Domain.Entities.Definitions.HumanResourcesManagement.EmployeeList
{
    public class EmployeeBranch : BaseEntity
    {
        public string BranchName { get; set; }
        public Employee  Employee { get; set; }
    }
}
