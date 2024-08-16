using BaseProject.Domain.Entities.GCrm.Enums;
using GCrm.Application.VMs.Definitions;
namespace GCrm.Application.Features.Commands.Definitions.Customer.Create
{
    public class CreateCustomerResponse
    {
        public string Id { get; set; }

        //public string? Code { get; set; }      

        public string Name { get; set; }

        public string? DefaultContactId { get; set; }

        public string? CustomerGroupId { get; set; }

        public string CustomerStatusId { get; set; }

        public string? CustomerKindId { get; set; }

        public string? CustomerTypeId { get; set; }

        public string CustomerSectorId { get; set; }

        public string CustomerSourceId { get; set; }

        public bool IsActive { get; set; }

        public string CustomerRepresentativeId { get; set; }

        public string? Description { get; set; }

        public bool TrackStatus { get; set; }

        public string? TaxOffice { get; set; }

        public string? TaxNo { get; set; }

        public CurrencyTypeEnum CurrencyType { get; set; }

        public PaymentTypeEnum? PaymentType { get; set; }

        public string? PaymentMethod { get; set; }

        public RiskStatusEnum? RiskStatus { get; set; }

        public string? SkypeAddress { get; set; }

        public string? LinkedinAddress { get; set; }

        public string? FacebookAddress { get; set; }

        public string? TwitterAddress { get; set; }

        public double? CustomerRating { get; set; }

        public string? FilePath { get; set; }


        public string? Phone { get; set; } //bu

        public string? Phone2 { get; set; } //bu

        public string? FaxNo { get; set; } //bu

        public string? Mobile { get; set; } //bu

        public string Email1 { get; set; } // bu

        public string? Email2 { get; set; } //bu

        public string? WebAddress { get; set; } //bu

        public ICollection<CustomerAddressVM>  CustomerAddress { get; set; }      

        public ICollection<CustomerCategoryVM> CustomerCategory { get; set; }

        public ICollection<CustomerContactListVM> CustomerContact { get; set; }

        //public ICollection<CustomerContactCreateVM>? CustomerContact { get; set; }
        public string? CompanyId { get; set; }
        public List<string> MessageList { get; set; }
    }
}