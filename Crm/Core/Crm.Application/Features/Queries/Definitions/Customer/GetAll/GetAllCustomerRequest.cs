using MediatR;
using Utilities.Core.UtilityApplication.RequestParameters;

namespace GCrm.Application.Features.Queries.Definitions.Customer.GetAll
{
    public class GetAllCustomerRequest : Pagination, IRequest<GetAllCustomerResponse>
    {
        public string? CompanyId { get; set; }
    }
}