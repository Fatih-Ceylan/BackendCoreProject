using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utilities.Core.UtilityDomain.Entities;

namespace GCrm.Domain.Entities.Definitions.HumanResourcesManagement.EmployeeList
{
    public class Department : BaseEntity
    {
        public string DepartmentName { get; set; }
        public Employee  Employee { get; set; }
    }
}
