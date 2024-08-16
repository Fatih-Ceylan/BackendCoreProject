using Card.Application.VMs;
using MediatR;

namespace Card.Application.Features.Commands.Definitions.StaffField.UpdateWithList
{
    public class UpdateWithListStaffFieldRequest:IRequest<UpdateWithListStaffFieldResponse>
    {
        public List<StaffFieldVM> StaffFields { get; set; }
    }
}
