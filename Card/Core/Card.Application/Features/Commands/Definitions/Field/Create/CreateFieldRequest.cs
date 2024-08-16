using MediatR;

namespace Card.Application.Features.Commands.Definitions.Field.Create
{
    public class CreateFieldRequest : IRequest<CreateFieldResponse>
    {
        public string Name { get; set; } 
    }
}
