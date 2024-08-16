using MediatR;

namespace GControl.Application.Features.Queries.Definitions.Location.GetById
{
    public class GetByIdLocationRequest : IRequest<GetByIdLocationResponse>
    {
        public string Id { get; set; }
    }
}
