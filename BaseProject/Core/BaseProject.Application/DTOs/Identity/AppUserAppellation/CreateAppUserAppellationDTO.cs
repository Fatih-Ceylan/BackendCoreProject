namespace BaseProject.Application.DTOs.Identity.AppUserAppellation
{
    public class CreateAppUserAppellationDTO
    {
        public string Name { get; set; }

        public string? MainAppellationId { get; set; }

        public string? CompanyId { get; set; }

        public string? BranchId { get; set; }
    }
}
