using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utilities.Core.UtilityDomain.Entities;

namespace GCrm.Domain.Entities.Definitions.ActivitiesManagement.Activities
{
    public  class CustomerActivitySubject : BaseEntity
    {
        public string Name { get; set; }

        public CustomerActivity CustomerActivity { get; set; }
    }
}
