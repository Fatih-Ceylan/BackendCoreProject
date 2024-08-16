using BaseProject.Domain.Entities.Definitions;
using BaseProject.Domain.Entities.GCrm.Definitions.CustomerManagement.Contacts;
using BaseProject.Domain.Entities.GCrm.Definitions.CustomerManagement.Customers;
using Utilities.Core.UtilityDomain.Entities;

namespace BaseProject.Domain.Entities.GCrm.Definitions.ActivitiesManagement.Activities
{
    public class CustomerActivity : BaseEntity
    {
        public string? Code { get; set; }
        public Guid CustomerId { get; set; }
        public Guid CustomerContactId { get; set; }
        public Guid CustomerActivitySubjectId { get; set; }
        public Guid CustomerActivityTypeId { get; set; }
        public Guid CustomerActivityKindId { get; set; }
        public Guid CustomerActivityStatusId { get; set; }
        public DateTime? ActivityDate { get; set; }
        public DateTime? ReminderDate { get; set; }
        public string? OfferCode { get; set; } // teklif kodu şimdilik tablodan almayacak verıyı
        public string? ProjectCode { get; set; } // proje kodu şimdilik tablodan almayacak verıyı
        public string? OpportunityCode { get; set; } // fırsat kodu şimdilik tablodan almayacak verıyı
        public bool EmailStatus { get; set; }
        public string? ActivityAddress { get; set; }
        public string? ActivityDescription { get; set; }
        //public ICollection<string>? FilePath { get; set; }
        public Customer Customer { get; set; }
        public CustomerContact CustomerContact { get; set; }
        public CustomerActivityKind CustomerActivityKind { get; set; }
        public CustomerActivityType CustomerActivityType { get; set; }
        public CustomerActivityStatus CustomerActivityStatus { get; set; }
        public CustomerActivitySubject CustomerActivitySubject { get; set; }
        //public ICollection<CustomerActivityFile> CustomerActivityFiles { get; set; }
        public ICollection<CustomerActivityTeam> CustomerActivityTeams { get; set; }
        public Guid? CompanyId { get; set; }
        public Guid? BranchId { get; set; }
        public Branch Branch { get; set; }
    }
}
