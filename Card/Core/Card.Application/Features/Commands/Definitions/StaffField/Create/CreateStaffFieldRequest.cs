using MediatR;

namespace Card.Application.Features.Commands.Definitions.StaffField.Create
{
    public class CreateStaffFieldRequest : IRequest<CreateStaffFieldResponse>
    {
        public string FieldId { get; set; }
        public int RowNumber { get; set; }
        public string StaffId { get; set; }
        public string CompanyId { get; set; }
        public string BranchId { get; set; }
    }
}
