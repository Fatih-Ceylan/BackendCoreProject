using GCrm.Application.Repositories.ReadRepository;
using GCrm.Application.VMs.Definitions;
using MediatR;

namespace GCrm.Application.Features.Queries.Definitions.CustomerActivityTeam.GetById
{
    public class GetByIdCustomerActivityTeamHandler : IRequestHandler<GetByIdCustomerActivityTeamRequest, GetByIdCustomerActivityTeamResponse>
    {
        readonly ICustomerActivityTeamReadRepository _customerActivityTeamReadRepository;

        public GetByIdCustomerActivityTeamHandler (ICustomerActivityTeamReadRepository customerActivityTeamReadRepository)
        {
            _customerActivityTeamReadRepository = customerActivityTeamReadRepository;

        }
        public async  Task<GetByIdCustomerActivityTeamResponse> Handle(GetByIdCustomerActivityTeamRequest request, CancellationToken cancellationToken)
        {
            var customeractivityteams = _customerActivityTeamReadRepository
                           .GetWhere(cat => cat.Id == Guid.Parse(request.Id), false)
                           .Select(cat => new CustomerActivityTeamVM
                           {
                               Id = cat.Id.ToString(),
                               Name =cat.Name,
                       
                               CreatedDate = cat.CreatedDate
                           }).FirstOrDefault();



            return new()
            {
                customerActivityTeam = customeractivityteams
            };
        }
    }
}
