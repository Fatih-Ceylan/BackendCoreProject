using MediatR;

namespace HR.Application.Features.Commands.Definitions.Employment.Location.Create
{
    public class CreateLocationRequest : IRequest<CreateLocationResponse>
    {
        public string Address { get; set; }

        public string City { get; set; }

        public string Province { get; set; }
    }
}
