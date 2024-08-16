using MediatR;

namespace Platform.Application.Features.Queries.Definitions.GModule.GetById
{
    public class GetByIdGModuleRequest : IRequest<GetByIdGModuleResponse>
    {
        public string Id { get; set; }
    }
}
