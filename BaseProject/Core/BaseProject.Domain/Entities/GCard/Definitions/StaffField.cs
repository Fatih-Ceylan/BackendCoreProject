﻿using BaseProject.Domain.Entities.Definitions;
using Utilities.Core.UtilityDomain.Entities;

namespace BaseProject.Domain.Entities.Card.Definitions
{
    public class StaffField : BaseEntity
    {
        public int RowNumber { get; set; }
        public Guid StaffId { get; set; }
        public Staff Staff { get; set; }
        public Guid FieldId { get; set; }
        public Field Field { get; set; }
        public Guid? CompanyId { get; set; } 
        public Guid? BranchId { get; set; }
        public Branch? Branch { get; set; }

    }
}