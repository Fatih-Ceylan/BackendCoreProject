using MediatR;

namespace GCrm.Application.Features.Commands.Definitions.CustomerActivityTeam.Delete
{
    public class DeleteCustomerActivityTeamRequest : IRequest<DeleteCustomerActivityTeamResponse>
    {
        public string  Id { get; set; }
    }
}
