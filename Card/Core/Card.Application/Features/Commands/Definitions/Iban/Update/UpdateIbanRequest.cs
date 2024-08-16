using MediatR;

namespace Card.Application.Features.Commands.Definitions.Iban.Update
{
    public class UpdateIbanRequest : IRequest<UpdateIbanResponse>
    {
        public string Id { get; set; }
        public string IbanNo { get; set; }
        public string StaffId { get; set; }
        public string CompanyId { get; set; }
        public string BranchId { get; set; }
    }
}
