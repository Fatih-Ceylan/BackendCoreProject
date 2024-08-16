using MediatR;
using Utilities.Core.UtilityApplication.RequestParameters;

namespace Card.Application.Features.Queries.Definitions.Iban.GetAll
{
    public class GetAllIbanRequest : Pagination, IRequest<GetAllIbanResponse>
    {
        public string CompanyId { get; set; }
        public string BranchId { get; set; }
    }
}
