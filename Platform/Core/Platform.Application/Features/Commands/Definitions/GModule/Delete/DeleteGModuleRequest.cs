using MediatR;

namespace Platform.Application.Features.Commands.Definitions.GModule.Delete
{
    public class DeleteGModuleRequest : IRequest<DeleteGModuleResponse>
    {
        public string Id { get; set; }

    }
}
