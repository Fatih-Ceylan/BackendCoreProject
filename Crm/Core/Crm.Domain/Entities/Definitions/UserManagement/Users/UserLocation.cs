using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utilities.Core.UtilityDomain.Entities;

namespace GCrm.Domain.Entities.Definitions.UserManagement.Users
{
    public class UserLocation : BaseEntity
    {
        public string LocationName { get; set; }
        public Users Users { get; set; }
    }
}
