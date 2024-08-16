using MediatR;

namespace Card.Application.Features.Queries.Definitions.PhoneNumber.GetById
{
    public class GetByIdPhoneNumberRequest : IRequest<GetByIdPhoneNumberResponse>
    {
        public string Id { get; set; }
    }
}
