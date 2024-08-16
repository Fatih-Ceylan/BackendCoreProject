using MediatR;

namespace Card.Application.Features.Commands.Definitions.Field.Delete
{
    public class DeleteFieldRequest : IRequest<DeleteFieldResponse>
    {
        public string Id { get; set; }
    }
}
