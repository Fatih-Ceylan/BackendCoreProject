﻿using Utilities.Core.UtilityDomain.Entities;

namespace BaseProject.Domain.Entities.GCrm.Definitions.OpportunityManagement.Opportunity
{
    public class OpportunitySector : BaseEntity
    {
        public string Name { get; set; }
        public ICollection<Opportunity> Opportunities { get; set; }

    }
}