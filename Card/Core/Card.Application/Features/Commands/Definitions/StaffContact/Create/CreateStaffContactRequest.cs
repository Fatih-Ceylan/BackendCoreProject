using MediatR;

namespace Card.Application.Features.Commands.Definitions.StaffContact.Create
{
    public class CreateStaffContactRequest : IRequest<CreateStaffContactResponse>
    {
        public string StaffId { get; set; }
        public string ContactId { get; set; }
        public string ContactName { get; set; }
        public string CompanyId { get; set; }
        public string BranchId { get; set; }

    }
}
