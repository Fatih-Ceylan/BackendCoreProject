using MediatR;
using Utilities.Core.UtilityApplication.RequestParameters;

namespace GCrm.Application.Features.Queries.Definitions.CustomerContact.GetAll
{
    public class GetAllCustomerContactRequest : Pagination, IRequest<GetAllCustomerContactResponse>
    {
        public string? CompanyId { get; set; }
    }
}
