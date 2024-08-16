using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utilities.Core.UtilityDomain.Entities;

namespace GCrm.Domain.Entities.Definitions.UserManagement.Users
{
    public class UsersDepartment : BaseEntity
    {
        public string DepartmentName { get; set; }
        public Users Users { get; set; }
    }
}
