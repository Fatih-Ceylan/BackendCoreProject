using MediatR;

namespace BaseProject.Application.Features.Commands.Identity.AppUserAppellation.Create
{
    public class CreateAppUserAppellationRequest : IRequest<CreateAppUserAppellationResponse>
    {
        public string Name { get; set; }

        public string? MainAppellationId { get; set; }

        public string? CompanyId { get; set; }

        public string? BranchId { get; set; }
    }
}
