using MediatR;
using Utilities.Core.UtilityApplication.RequestParameters;

namespace GCrm.Application.Features.Queries.Definitions.CompanyTender.GetAll
{
    public  class GetAllCompanyTenderRequest : Pagination, IRequest<GetAllCompanyTenderResponse>
    {
    }
}
