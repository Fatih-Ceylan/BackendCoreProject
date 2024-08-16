using Utilities.Core.UtilityApplication.VMs;

namespace Card.Application.VMs
{
    public class StaffVM : BaseVM
    {
        public string? Id { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Title { get; set; }
        public string QrCodePath { get; set; }
        public string? Description { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string? Token { get; set; }
        public string PhoneNumber { get; set; }
        public string? ProfilePicturePath { get; set; }
        public string? FileName { get; set; }
        public string CompanyId { get; set; }
        public string CompanyName { get; set; }
        public string BranchId { get; set; }
        public string BranchName { get; set; }
        public string? StaffUrl { get; set; }
        public List<SocialMediaUrlVM> SocialMedias { get; set; }
        public List<StaffContactVM>? Contacts { get; set; }
    }
}
