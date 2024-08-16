using MediatR;

namespace GCrm.Application.Features.Queries.Definitions.CustomerActivityTeam.GetById
{
    public  class GetByIdCustomerActivityTeamRequest : IRequest<GetByIdCustomerActivityTeamResponse>
    {
        public string  Id { get; set; }
    }
}
