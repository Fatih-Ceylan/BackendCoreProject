namespace BaseProject.Application.DTOs.Identity.AppUser
{
    public class CreateUserRequestDTO
    {
        public string? ProfileImagePath { get; set; }

        public string FullName { get; set; }

        public string UserName { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }

        public string PasswordConfirm { get; set; }

        public string CompanyId { get; set; }

        public string BranchId { get; set; }

        public string DepartmentId { get; set; }

        public string? AppUserAppellationId { get; set; }
    }
}
