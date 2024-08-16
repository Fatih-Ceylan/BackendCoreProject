using MediatR;

namespace NLLogistics.Application.Features.Commands.Definitions.Port.Delete
{
    public class DeletePortRequest: IRequest<DeletePortResponse>
    {
        public string Id { get; set; }

    }
}
