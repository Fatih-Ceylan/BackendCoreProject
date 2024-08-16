namespace BaseProject.Application.VMs.Definitions.AppUser
{
    public class AppUserVM
    {
        public string Id { get; set; }

        public string? ProfileImagePath { get; set; }

        public string FullName { get; set; }

        public string UserName { get; set; }

        public string Email { get; set; }

        public string CompanyId { get; set; }

        public string CompanyName { get; set; }

        public string BranchId { get; set; }

        public string BranchName { get; set; }

        public string DepartmentId { get; set; }

        public string DepartmentName { get; set; }

        public string? AppUserAppellationId { get; set; }

        public string? AppUserAppellationName { get; set; }

    }
}