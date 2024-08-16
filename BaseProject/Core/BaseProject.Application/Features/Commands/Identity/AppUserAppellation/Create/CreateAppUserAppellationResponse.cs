namespace BaseProject.Application.Features.Commands.Identity.AppUserAppellation.Create
{
    public class CreateAppUserAppellationResponse
    {
        public string Id { get; set; }

        public string Name { get; set; }

        public string MainAppellationId { get; set; }

        public string CompanyId { get; set; }

        public string BranchId { get; set; }

        public string Message { get; set; }
    }
}
