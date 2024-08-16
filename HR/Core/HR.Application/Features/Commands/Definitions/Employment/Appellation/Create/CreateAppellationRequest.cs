using MediatR;

namespace HR.Application.Features.Commands.Definitions.Employment.Appellation.Create
{
    public class CreateAppellationRequest : IRequest<CreateAppellationResponse>
    {

        public string Code { get; set; }

        public string Name { get; set; }

        public string? MainAppellationId { get; set; }
    }
}
