using MediatR;

namespace GControl.Application.Features.Commands.Definitions.EntryExitManagement.Create
{
    public class CreateEntryExitManagementRequest : IRequest<CreateEntryExitManagementResponse>
    {
        public string EmployeeId { get; set; }
        public string LocationId { get; set; }
        public DateTime DateTime { get; set; }
        public bool IsLocationOut { get; set; }
        public bool IsRegistrationType { get; set; }
        public string Description { get; set; }
        public string CompanyId { get; set; }
    }
}
