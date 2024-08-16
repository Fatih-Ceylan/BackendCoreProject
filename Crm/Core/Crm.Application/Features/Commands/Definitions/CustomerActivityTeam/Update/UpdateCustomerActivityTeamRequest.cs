using MediatR;

namespace GCrm.Application.Features.Commands.Definitions.CustomerActivityTeam.Update
{
    public class UpdateCustomerActivityTeamRequest : IRequest<UpdateCustomerActivityTeamResponse>
    {
        public string Id { get; set; }
        public string Name { get; set; }
    }
}
