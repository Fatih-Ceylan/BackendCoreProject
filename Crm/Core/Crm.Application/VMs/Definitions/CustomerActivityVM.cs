using Utilities.Core.UtilityDomain.Entities;

namespace GCrm.Application.VMs.Definitions
{
    public class CustomerActivityVM : BaseEntity
    {
        public string CustomerId { get; set; }
        public string CustomerName { get; set; }
        public string? Code { get; set; }
        public string CustomerStatusName { get; set; }
        public string CustomerPhone { get; set; }
        public string CustomerMail { get; set; }
        public int? CustomerCityId { get; set; }
        public string CustomerCityName { get; set; }
        public string CustomerDistrictName { get; set; }
        public string CustomerSectorId { get; set; }
        public string CustomerSectorName { get; set; }
        public string CustomerGroupId { get; set; }
        public string CustomerGroupName { get; set; }
        public string CustomerContactId { get; set; }
        public string CustomerContactName { get; set; }
        public string CustomerContactPhone { get; set; }
        public string CustomerContactMail { get; set; }
        public string CustomerContactTitleId { get; set; }
        public string CustomerContactTitleName { get; set; }
        public string CustomerActivitySubjectId { get; set; }
        public string CustomerActivitySubjectName { get; set; }
        public string CustomerActivityTypeId { get; set; }
        public string CustomerActivityTypeName { get; set; }
        public string CustomerActivityKindId { get; set; }
        public string CustomerActivityKindName { get; set; }
        public string CustomerActivityStatusId { get; set; }
        public string CustomerActivityStatusName { get; set; }
        public DateTime? ActivityDate { get; set; }
        public DateTime? ReminderDate { get; set; }
        public bool EmailStatus { get; set; }
        public string? ActivityAddress { get; set; }
        public string? OfferCode { get; set; } //teklif kodu şimdilik tablodan almayacak verıyı
        public string? ProjectCode { get; set; } // proje kodu şimdilik tablodan almayacak verıyı
        public string? OpportunityCode { get; set; } // fırsat kodu şimdilik tablodan almayacak verıyı
        public string? ActivityDescription { get; set; }
        public string? CompanyId { get; set; }
        //public string? BranchId { get; set; }
        public List<CustomerActivityTeamVM> CustomerActivityTeams { get; set; }
        public List<CustomerCategoryVM> CustomerCategories { get; set; }

    }
}
