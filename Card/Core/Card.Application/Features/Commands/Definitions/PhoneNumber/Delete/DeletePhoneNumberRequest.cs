using MediatR;

namespace Card.Application.Features.Commands.Definitions.PhoneNumber.Delete
{
    public class DeletePhoneNumberRequest : IRequest<DeletePhoneNumberResponse>
    {
        public string Id { get; set; }
    }
}
