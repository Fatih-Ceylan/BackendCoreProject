using MediatR;

namespace GCrm.Application.Features.Commands.Definitions.CustomerRepresentative.Update
{
    public  class UpdateCustomerRepresentativeRequest : IRequest<UpdateCustomerRepresentativeResponse>
    {
        public string  Id { get; set; }
    }
}
