namespace GCharge.Application.VMs.Definitions
{
    public class UserChargeTagVM
    {
        public string UserId { get; set; }
        public string? UserName { get; set; }
        public string TagId { get; set; }
        public string? TagName { get; set; }
        public DateTime? ExpiryDate { get; set; } 
        public bool? Blocked { get; set; } 
    }
}
