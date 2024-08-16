using MediatR;

namespace GCrm.Application.Features.Commands.Definitions.CustomerActivityTeam.Create
{
    public class CreateCustomerActivityTeamRequest : IRequest<CreateCustomerActivityTeamResponse>
    {   
        public string Name { get; set; }
    }
}
