using GCharge.Domain.Entities.Definitions;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace OCPP.Core.Management.Models
{
    public class UserChargeTagViewModel
    {
        public string UserId { get; set; }
        public string Mail { get; set; }

        [Display(Name = "Tag ID")]
        public string TagId { get; set; }
        public string ParentTagId { get; set; }
        public List<UserChargeTag> UserChargeTags { get; set; } = new List<UserChargeTag>();


    }
}
