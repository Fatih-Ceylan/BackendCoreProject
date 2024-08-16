namespace Utilities.Core.UtilityApplication.DTOs.Identity.AppUser
{
    public class CurrentUserDTO
    {
        public string Id { get; set; }

        public string FullName { get; set; }

        public string UserName { get; set; }

        public string Email { get; set; }

        public  string? UrlPath { get; set; }

        public string? MasterCompanyIdFromPlatform { get; set; }

        public string? CompanyId { get; set; }

        public string? CompanyName { get; set; }

        public string? BranchId { get; set; }

        public string? BranchName { get; set; }

        public string? DepartmentId { get; set; }

        public string? DepartmentName { get; set; }

        public string? IdTag { get; set; }
    }
}