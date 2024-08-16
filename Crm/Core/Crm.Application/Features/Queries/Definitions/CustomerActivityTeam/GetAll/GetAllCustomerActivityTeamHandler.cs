using GCrm.Application.Repositories.ReadRepository;
using GCrm.Application.VMs.Definitions;
using MediatR;

namespace GCrm.Application.Features.Queries.Definitions.CustomerActivityTeam.GetAll
{
    public class GetAllCustomerActivityTeamHandler : IRequestHandler<GetAllCustomerActivityTeamRequest, GetAllCustomerActivityTeamResponse>
    {
        readonly ICustomerActivityTeamReadRepository _customerActivityTeamReadRepository;

        public GetAllCustomerActivityTeamHandler(ICustomerActivityTeamReadRepository customerActivityTeamReadRepository)
        {
            _customerActivityTeamReadRepository = customerActivityTeamReadRepository;
        }

        public Task<GetAllCustomerActivityTeamResponse> Handle(GetAllCustomerActivityTeamRequest request, CancellationToken cancellationToken)
        {
            var query = _customerActivityTeamReadRepository.GetAllDeletedStatusDesc(false)
              .Select(cat => new CustomerActivityTeamVM
              {
                  Id = cat.Id.ToString(),
                  Name = cat.Name,
                  CreatedDate = cat.CreatedDate,
              });

            var totalCount = query.Count();
            var customeractivityteams = query.Skip(request.Page * request.Size)
                                 .Take(request.Size).ToList();

            return Task.FromResult(new GetAllCustomerActivityTeamResponse
            {
                TotalCount = totalCount,
                customerActivityTeams = customeractivityteams,
            });
        }
    }
}
