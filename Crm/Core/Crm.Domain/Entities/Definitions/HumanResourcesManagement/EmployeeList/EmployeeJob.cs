using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utilities.Core.UtilityDomain.Entities;

namespace GCrm.Domain.Entities.Definitions.HumanResourcesManagement.EmployeeList
{
    public class EmployeeJob : BaseEntity
    {
        public string JobName { get; set; }
        public Employee  Employee { get; set; }
    }
}
