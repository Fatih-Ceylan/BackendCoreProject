using MediatR;

namespace Card.Application.Features.Commands.Definitions.Iban.Delete
{
    public class DeleteIbanRequest : IRequest<DeleteIbanResponse>
    {
        public string Id { get; set; }
    }
}
