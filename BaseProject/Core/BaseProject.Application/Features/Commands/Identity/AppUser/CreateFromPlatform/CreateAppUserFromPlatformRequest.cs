using MediatR;

namespace BaseProject.Application.Features.Commands.Identity.AppUser.CreateFromPlatform
{
    public class CreateAppUserFromPlatformRequest : IRequest<CreateAppUserFromPlatformResponse>
    {
        public string ProfileImagePath { get; set; }

        public string FullName { get; set; }

        public string UserName { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }

        public string PasswordConfirm { get; set; }

        public string CompanyId { get; set; }

        public string BranchId { get; set; }

        public string DepartmentId { get; set; }

    }
}