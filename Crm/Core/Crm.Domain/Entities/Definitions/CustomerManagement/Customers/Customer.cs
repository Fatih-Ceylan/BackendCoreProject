using GCrm.Domain.Entities.Definitions.ActivitiesManagement.Activities;
using GCrm.Domain.Entities.Definitions.CustomerManagement.Contacts;
using GCrm.Domain.Entities.Definitions.ProjectManagement.Projects;
using GCrm.Domain.Enums;
using Utilities.Core.UtilityDomain.Entities;


namespace GCrm.Domain.Entities.Definitions.CustomerManagement.Customers
{
    public class Customer : BaseEntity
    {
        public string? Code { get; set; }

        public string Name { get; set; }

        public Guid? CustomerGroupId { get; set; }

        public Guid? DefaultContactId { get; set; }

        public Guid CustomerStatusId { get; set; }

        public Guid? CustomerKindId { get; set; }

        public Guid? CustomerTypeId { get; set; }

        public Guid CustomerRepresentativeId { get; set; }

        public Guid CustomerSectorId { get; set; }

        public Guid CustomerSourceId { get; set; }

        public bool IsActive { get; set; }

        public string? Description { get; set; }

        public bool TrackStatus { get; set; }

        public string? TaxOffice { get; set; }

        public string? TaxNo { get; set; }

        public PaymentTypeEnum? PaymentType { get; set; }

        public CurrencyTypeEnum? CurrencyType { get; set; }

        public string? PaymentMethod { get; set; }

        public RiskStatusEnum? RiskStatus { get; set; }

        public string? SkypeAddress { get; set; }

        public string? LinkedinAddress { get; set; }

        public string? FacebookAddress { get; set; }

        public string? TwitterAddress { get; set; }

        public double? CustomerRating { get; set; }

        public string? FilePath { get; set; }

        public CustomerGroup? CustomerGroup { get; set; }

        public ICollection<CustomerContact>? CustomerContacts { get; set; }

        public CustomerStatus CustomerStatus { get; set; }

        public CustomerKind? CustomerKind { get; set; }

        public CustomerType? CustomerType { get; set; }

        public ICollection<CustomerCategory>? CustomerCategories { get; set; }

        public CustomerSector CustomerSector { get; set; }

        public CustomerSource CustomerSource { get; set; }

        public ICollection<CustomerAddress> CustomerAddresses { get; set; }

        public ICollection<CustomerActivity> CustomerActivities { get; set; }

        public CustomerRepresentative CustomerRepresentatives { get; set; }

        public ICollection<Project> Projects { get; set; } // proje yonetımındekı musterı adı ıcın


    }
}