using MediatR;

namespace GCharge.Application.Features.Commands.Definitions.ChargeTag.Create
{
    public class CreateChargeTagRequest : IRequest<CreateChargeTagResponse>
    {
        public string TagId { get; set; }
        public string TagName { get; set; }
        public string? ParentTagId { get; set; }
        public DateTime? ExpiryDate { get; set; }
        public bool? Blocked { get; set; }
    }
}
