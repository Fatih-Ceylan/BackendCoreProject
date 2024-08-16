using MediatR;

namespace HR.Application.Features.Commands.Definitions.Employment.Appellation.Update
{
    public class UpdateAppellationRequest : IRequest<UpdateAppellationResponse>
    {
        public string Id { get; set; }

        public int? Code { get; set; }

        public string? Name { get; set; }

        public string? MainAppellationId { get; set; }
    }
}
