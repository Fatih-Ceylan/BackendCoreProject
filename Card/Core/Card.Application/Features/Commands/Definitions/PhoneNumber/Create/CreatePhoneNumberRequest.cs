using MediatR;

namespace Card.Application.Features.Commands.Definitions.PhoneNumber.Create
{
    public class CreatePhoneNumberRequest : IRequest<CreatePhoneNumberResponse>
    {
        public string Number { get; set; }
        public string StaffId { get; set; }
        public string CompanyId { get; set; }
        public string BranchId { get; set; }
    }
}
