using BaseProject.Domain.Entities.Card.Definitions;
using BaseProject.Domain.Entities.GControl.Definitions;

namespace BaseProject.Domain.Entities.Definitions
{
    public class Branch : B_BaseEntity
    {
        public Guid CompanyId { get; set; }

        public string Code { get; set; }

        public string Name { get; set; }

        public string? AuthorizedFullName { get; set; }

        public string? FullAddress { get; set; }

        public string? PostalCode { get; set; }

        public string? PhoneNumber { get; set; }

        public string? Email { get; set; }

        public int? CountryId { get; set; }

        public int? CityId { get; set; }

        public int? DistrictId { get; set; }

        public Company Company { get; set; }

        public District? District { get; set; }

        public ICollection<Department> Departments { get; set; }

        public ICollection<MailCredential> MailCredentials { get; set; }

        #region Card

        public ICollection<Address> CardAddresses { get; set; }
        public ICollection<Cargo> CardCargos { get; set; }
        public ICollection<Field> CardFields { get; set; }
        public ICollection<Iban> CardIbans { get; set; }
        public ICollection<Invoice> CardInvoices { get; set; }
        public ICollection<Order> CardOrders { get; set; }
        public ICollection<OrderDetail> CardDetails { get; set; }
        public ICollection<PhoneNumber> CardPhoneNumbers { get; set; }
        public ICollection<SocialMedia> CardSocialMedias { get; set; }
        public ICollection<SocialMediaUrl> CardSocialMediaUrls { get; set; }
        public ICollection<Staff> CardStaffs { get; set; }
        public ICollection<StaffContact> CardStaffContacts { get; set; }
        public ICollection<StaffField> CardStaffFields { get; set; }

        #endregion

        #region GControl
        public ICollection<Employee> GControlEmployees { get; set; }
        public ICollection<EntryExitManagement> GControlEntryExitManagement { get; set; }
        #endregion

    }
}