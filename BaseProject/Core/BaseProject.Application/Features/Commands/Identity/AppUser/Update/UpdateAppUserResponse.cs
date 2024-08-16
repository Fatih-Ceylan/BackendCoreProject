namespace BaseProject.Application.Features.Commands.Identity.AppUser.Update
{
    public class UpdateAppUserResponse
    {
        public string Id { get; set; }

        public string? Files { get; set; }

        public string FullName { get; set; }

        public string UserName { get; set; }

        public string Email { get; set; }

        public string CompanyId { get; set; }

        public string BranchId { get; set; }

        public string DepartmentId { get; set; }

        public string? AppUserAppellationId { get; set; }

        public bool Succeed { get; set; }

        public List<string> MessageList { get; set; }
    }
}