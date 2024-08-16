using Utilities.Core.UtilityApplication.VMs;

namespace GCrm.Application.VMs.Definitions
{
    public  class CustomerActivityGetByIdVM : BaseVM
    {
        public string CustomerId { get; set; }
        public string CustomerName { get; set; }
        public string CustomerContactId { get; set; }
        public string CustomerContactName { get; set; }
        public string CustomerActivitySubjectId { get; set; }
        public string CustomerActivityTypeId { get; set; }
        public string CustomerActivityKindId { get; set; }
        public string CustomerActivityStatusId { get; set; }
        public DateTime? ActivityDate { get; set; }
        public DateTime? ReminderDate { get; set; }
        public bool EmailStatus { get; set; }
        public string? ActivityAddress { get; set; }
        public string? OfferCode { get; set; } //teklif kodu şimdilik tablodan almayacak verıyı
        public string? ProjectCode { get; set; } // proje kodu şimdilik tablodan almayacak verıyı
        public string? OpportunityCode { get; set; } // fırsat kodu şimdilik tablodan almayacak verıyı
        public string? ActivityDescription { get; set; }   
        public List<CustomerActivityTeamVM> CustomerActivityTeams { get; set; }
        public List<CustomerContactIdNameVM> CustomerContacts { get; set; }
        public string? CompanyId { get; set; }
        //public string? BranchId { get; set; }
    }
}
