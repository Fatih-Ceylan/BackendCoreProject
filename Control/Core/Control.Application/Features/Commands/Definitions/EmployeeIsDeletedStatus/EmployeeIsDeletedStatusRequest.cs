using MediatR;

namespace GControl.Application.Features.Commands.Definitions.EmployeeIsDeletedStatus
{
    public class EmployeeIsDeletedStatusRequest : IRequest<EmployeeIsDeletedStatusResponse>
    {
        public string Id { get; set; }
        public bool isDeleted { get; set; }
    }
}
