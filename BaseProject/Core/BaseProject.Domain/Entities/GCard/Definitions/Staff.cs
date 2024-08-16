using BaseProject.Domain.Entities.Definitions;
using BaseProject.Domain.Entities.Card.Definitions.Files;
using Utilities.Core.UtilityDomain.Entities;

namespace BaseProject.Domain.Entities.Card.Definitions
{
    public class Staff : BaseEntity
    {
        //todo:forgot password yapılacak
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Title { get; set; }  
        public string? Description { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string? Token { get; set; }
        public string? PhoneNumber { get; set; }
        public string ProfilePicturePath { get; set; }
        public string? StaffUrl { get; set; }
        public Guid? CompanyId { get; set; }
        public Guid? BranchId { get; set; }
        public Branch Branch { get; set; }
        public ICollection<StaffField> StaffFields { get; set; }
        public ICollection<PhoneNumber> PhoneNumbers { get; set; } 
        public ICollection<Iban> Ibans { get; set; }  
        public ICollection<StaffFile> StaffFiles { get; set; }  
        public ICollection<SocialMediaUrl> SocialMediaUrls { get; set; }  
        public ICollection<StaffContact> StaffContacts { get; set; }
        public ICollection<OrderDetail> OrderDetails { get; set; }   
    }
}
