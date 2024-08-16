using BaseProject.Domain.Entities.GCrm.Enums;
using MediatR;

namespace GCrm.Application.Features.Commands.Definitions.Users.Update
{
    public  class UpdateUsersRequest : IRequest<UpdateUsersResponse>
    {
        public string Id { get; set; }
        public string UserName { get; set; }
        public string UserEmail { get; set; }
        public int UserPassword { get; set; }
        public int UserPasswordRepeat { get; set; }
        public bool DataTransfer { get; set; }
        public string UserCompany { get; set; }
        public Guid? UserLocationId { get; set; }
        public Guid? UserBranchId { get; set; }
        public Guid? UsersDepartmentId { get; set; }
        public Guid? UserTitleId { get; set; }
        public PriceNameEnum PriceNameEnum { get; set; }
        public GenderEnum GenderEnum { get; set; }
        public string HomePhone { get; set; }
        public string MobilePhone { get; set; }
        public string HomeAddress { get; set; }
        public string BirthPlace { get; set; }
        public DateTime BirthDate { get; set; }
        public DateTime StartWorkhDate { get; set; }
        public DateTime FinishWorkhDate { get; set; }
        public string IdentificationNumber { get; set; }
        public BloodGroupEnum BloodGroup { get; set; }
        public EducationalStatuEnum EducationalStatuEnum { get; set; }
        public string GraduationSchoolName { get; set; }
        public string GraduationFacultyName { get; set; }
        public DateTime GraduationSchoolDate { get; set; }
        public MaritalStatusEnum MaritalStatusEnum { get; set; }
        public DateTime MarriageDate { get; set; }
        public string BankAccountNumber { get; set; }
        public UserStatuEnum UserStatuEnum { get; set; }
        public bool AdminUser { get; set; }
        public string UserPicture { get; set; }
        public string UserSignature { get; set; }
    }
}
