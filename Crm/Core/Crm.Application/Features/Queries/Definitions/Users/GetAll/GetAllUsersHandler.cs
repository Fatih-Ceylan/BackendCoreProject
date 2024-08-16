using GCrm.Application.Repositories.ReadRepository;
using GCrm.Application.VMs.Definitions;
using MediatR;

namespace GCrm.Application.Features.Queries.Definitions.Users.GetAll
{
    public class GetAllUsersHandler : IRequestHandler<GetAllUsersRequest, GetAllUsersResponse>
    {
        readonly IUsersReadRepository _usersReadRepository;

        public GetAllUsersHandler(IUsersReadRepository  usersReadRepository)
        {
            _usersReadRepository = usersReadRepository;
        }

        public Task<GetAllUsersResponse> Handle(GetAllUsersRequest request, CancellationToken cancellationToken)
        {
            var query = _usersReadRepository
            .GetAllDeletedStatusDesc(false)
                        .Select(ck => new UsersVM
                        {
                            Id = ck.Id.ToString(),
                           
                        });

            var totalCount = query.Count();
            var users = query.Skip(request.Page * request.Size)
                                 .Take(request.Size).ToList();

            return Task.FromResult(new GetAllUsersResponse
            {
                TotalCount = totalCount,
                Users = users,
            });
        }
    }
}
