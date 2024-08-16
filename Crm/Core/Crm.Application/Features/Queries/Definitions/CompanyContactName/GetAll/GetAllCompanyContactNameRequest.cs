using MediatR;
using Utilities.Core.UtilityApplication.RequestParameters;

namespace GCrm.Application.Features.Queries.Definitions.CompanyContactName.GetAll
{
    public  class GetAllCompanyContactNameRequest : Pagination, IRequest<GetAllCompanyContactNameResponse>
    {
    }
}
