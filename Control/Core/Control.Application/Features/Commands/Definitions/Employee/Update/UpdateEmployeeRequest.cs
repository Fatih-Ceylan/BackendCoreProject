using MediatR;
using Microsoft.AspNetCore.Http;

namespace GControl.Application.Features.Commands.Definitions.Employee.Update
{
    public class UpdateEmployeeRequest : IRequest<UpdateEmployeeResponse>
    {
        public string Id { get; set; }
        public string RegistrationNumber { get; set; }
        public string FullName { get; set; }
        public string PhoneNumber { get; set; }
        public DateTime StartWorkDate { get; set; }
        public string Email { get; set; }
        public string? UserName { get; set; }
        public string? Password { get; set; }
        public string? EmployeeTypeId { get; set; }
        public string DepartmentId { get; set; }
        public bool isActive { get; set; }
        public string? ProfilePicturePath { get; set; }
        public string CompanyId { get; set; } 
        public IFormFileCollection? Files { get; set; }
        public List<string> EmployeeLabelsId { get; set; }
        public List<string> ShiftManagementsId { get; set; }
        public List<string> ApplicationSettingsId { get; set; }
    }
}


