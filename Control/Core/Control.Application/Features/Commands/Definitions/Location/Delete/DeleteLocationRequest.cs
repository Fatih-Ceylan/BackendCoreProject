using MediatR;

namespace GControl.Application.Features.Commands.Definitions.Location.Delete
{
    public class DeleteLocationRequest : IRequest<DeleteLocationResponse>
    {
        public string Id { get; set; }
    }
}
