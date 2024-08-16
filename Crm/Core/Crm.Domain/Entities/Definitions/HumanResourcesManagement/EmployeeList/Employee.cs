using GCrm.Domain.Entities.Definitions.OpportunityManagement.Opportunity;
using GCrm.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using Utilities.Core.UtilityDomain.Entities;

namespace GCrm.Domain.Entities.Definitions.HumanResourcesManagement.EmployeeList
{
    public class Employee : BaseEntity
    {
        public int Identificationnumber { get; set; } //tc kımlık no
        public int? InsuranceNumber { get; set; } //sgk numarası
        public string Name { get; set; } //personel adı
        public GenderEnum GenderEnum { get; set; } //cinsiyet
        public string EMail { get; set; }
        public int Password { get; set; }
        public int PasswordAgain { get; set; }
        public string BankInformation { get; set; }
        public int IbanNumber { get; set; }
        public Guid EmployeeLocationId { get; set; }
        public Guid EmployeeBranchId { get; set; }
        public Guid DepartmentId { get; set; }
        public Guid EmployeeTitleId { get; set; }
        public Guid EmployeeJobId { get; set; }
        public Guid EmployeeRolesId { get; set; }
        public EmployeeLocation EmployeeLocation { get; set; } //lokasyon
        public EmployeeBranch EmployeeBranch { get; set; } //şube
        public Department Department { get; set; }
        public EmployeeTitle EmployeeTitle { get; set; } //unvan
        public EmployeeJob EmployeeJob { get; set; } //meslek
        public string EmployeeDuty { get; set; } // görevi
        public string EmployeeDutyLocation { get; set; } // görev yeri
        public string CompanyPhone { get; set; } //sirket telefonu
        public string? EmployeePhone { get; set; } //şahsi telefonu
        public EmployeeStatu EmployeeStatu { get; set; } //durum
        public DateTime WorkStartDate { get; set; } //işe giriş tarihi
        public DateTime? WorkLeavingDate { get; set; } //işten cıkıs tarıhi
        public string? Address { get; set; }
        public bool StaffInformation { get; set; } //kadro bilgisi
        public string StaffRelative { get; set; } //ulasılamadıgında aranacak kısı
        public int StaffRelativePhone { get; set; } //aranacak kisi telefonu
        public double? AnnualLeaveEntitlement { get; set; } //yıllık izin sayısı
        public double? RemainingLeaveEntitlement { get; set; } //kalan izin sayısı
        public DrivingLicenseTypeEnum? DrivingLicenseTypeEnum { get; set; } //ehlıyet tipi
        public BloodGroupEnum? BloodGroup { get; set; } //kan grubu
        public MaritalStatusEnum? MaritalStatusEnum { get; set; } //medeni hali
        public DateTime? MaritalDate { get; set; } //evlılık tarıhı
        public DateTime? BirthDate { get; set; } //dogum tarihi
        public string? BirthPlace { get; set; } //dogum yeri
        public int? ChildrenNumber { get; set; } //cocuk sayısı
        public ShoesSizeEnum? ShoesSizeEnum { get; set; } //ayakkabı olcusu
        public LowerBodyEnum? LowerBodyEnum { get; set; } //alt beden bılgısı
        public UpperBodyEnum? UpperBodyEnum { get; set; } //üst beden bılgısı
        public string Description { get; set; } 
        public bool CrmUser { get; set; } //crm kullanıcısı mı
        public bool CrmUserAdmin { get; set; } //crm admin mi
        public int PDKSPersonId { get; set; } // pdks person idsi
        public ShiftEnum? ShiftEnum { get; set; } //calısan vardıya
        public EmployeeRoles? EmployeeRoles { get; set; } //calısan rollerı
        //public ICollection<Opportunity>  Opportunities { get; set; }

    }
}
