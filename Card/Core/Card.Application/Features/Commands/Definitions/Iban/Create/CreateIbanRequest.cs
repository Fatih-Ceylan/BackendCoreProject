using MediatR;

namespace Card.Application.Features.Commands.Definitions.Iban.Create
{
    public class CreateIbanRequest : IRequest<CreateIbanResponse>
    {
        public string IbanNo { get; set; }
        public string StaffId { get; set; }
        public string CompanyId { get; set; }
        public string BranchId { get; set; }
    }
}
