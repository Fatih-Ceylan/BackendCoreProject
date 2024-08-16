using BaseProject.Application.VMs.Definitions.AppUserLicense;
using MediatR;
using Utilities.Core.UtilityApplication.DTOs.File;

namespace BaseProject.Application.Features.Commands.Identity.AppUser.Create
{
    public class CreateAppUserRequest : IRequest<CreateAppUserResponse>
    {
        public List<FileOptionDTO>? FileOptions { get; set; }

        public string FullName { get; set; }

        public string UserName { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }

        public string PasswordConfirm { get; set; }

        public string CompanyId { get; set; }

        public string BranchId { get; set; }

        public string DepartmentId { get; set; }

        public string? AppUserAppellationId { get; set; }

        public List<AppUserLicenseCreateVM> AppUserLicenses { get; set; }
    }
}