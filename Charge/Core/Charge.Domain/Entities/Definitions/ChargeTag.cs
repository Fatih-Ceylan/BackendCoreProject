namespace GCharge.Domain.Entities.Definitions
{
    public class ChargeTag
    {
        public string TagId { get; set; }
        public string? TagName { get; set; }
        public string? ParentTagId { get; set; }
        public DateTime? ExpiryDate { get; set; }
        public bool? Blocked { get; set; }
        public ICollection<UserChargeTag> UserChargeTags { get; set; }
    }
}
