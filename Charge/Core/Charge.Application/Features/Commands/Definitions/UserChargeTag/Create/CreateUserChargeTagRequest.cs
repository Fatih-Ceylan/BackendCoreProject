using MediatR;

namespace GCharge.Application.Features.Commands.Definitions.UserChargeTag.Create
{
    public class CreateUserChargeTagRequest : IRequest<CreateUserChargeTagResponse>
    {
        public string UserId { get; set; }
        public string TagId { get; set; }
    }
}
