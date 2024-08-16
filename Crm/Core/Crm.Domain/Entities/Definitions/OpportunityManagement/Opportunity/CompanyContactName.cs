using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utilities.Core.UtilityDomain.Entities;

namespace GCrm.Domain.Entities.Definitions.OpportunityManagement.Opportunity
{
    public class CompanyContactName : BaseEntity
    {
        public string Name { get; set; }
        public Opportunity  Opportunity { get; set; }
    }
}
