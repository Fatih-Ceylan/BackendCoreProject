using GCrm.Application.Repositories.ReadRepository;
using GCrm.Application.VMs.Definitions;
using MediatR;

namespace GCrm.Application.Features.Queries.Definitions.Users.GetById
{
    public  class GetByIdUsersHandler : IRequestHandler<GetByIdUsersRequest,GetByIdUsersResponse>
    {
        readonly IUsersReadRepository _usersReadRepository;

        public GetByIdUsersHandler(IUsersReadRepository usersReadRepository)
        {
            _usersReadRepository = usersReadRepository;
        }

        public async Task<GetByIdUsersResponse> Handle(GetByIdUsersRequest request, CancellationToken cancellationToken)
        {
            var users = _usersReadRepository
                          .GetWhere(ck => ck.Id == Guid.Parse(request.Id), false)
                          .Select(ck => new UsersVM
                          {
                              //Id = ck.Id.ToString(),
                            
                          }).FirstOrDefault();

            return new()
            {
                Users = users
            };
        }
    }
}
