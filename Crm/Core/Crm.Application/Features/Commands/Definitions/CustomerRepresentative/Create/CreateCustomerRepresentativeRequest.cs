using MediatR;

namespace GCrm.Application.Features.Commands.Definitions.CustomerRepresentative.Create
{
    public  class CreateCustomerRepresentativeRequest : IRequest<CreateCustomerRepresentativeResponse>
    {
        public string Name { get; set; }
    }
}
