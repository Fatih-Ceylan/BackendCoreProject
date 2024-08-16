using MediatR;

namespace Card.Application.Features.Commands.Definitions.StaffContact.Update
{
    public class UpdateStaffContactRequest : IRequest<UpdateStaffContactResponse>
    {
        public string Id { get; set; }
        public string StaffId { get; set; }
        public string ContactId { get; set; }
        public string CompanyId { get; set; }
        public string BranchId { get; set; }
    }
}
