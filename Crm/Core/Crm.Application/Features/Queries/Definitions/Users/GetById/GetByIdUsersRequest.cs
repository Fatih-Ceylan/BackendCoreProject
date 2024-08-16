using MediatR;

namespace GCrm.Application.Features.Queries.Definitions.Users.GetById
{
    public class GetByIdUsersRequest : IRequest<GetByIdUsersResponse>
    {
        public string Id { get; set; }
    }
}
