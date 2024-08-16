using MediatR;

namespace Card.Application.Features.Commands.Definitions.Field.Update
{
    public class UpdateFieldRequest : IRequest<UpdateFieldResponse>
    {
        public string Id { get; set; }
        public string Name { get; set; } 
    }
}
