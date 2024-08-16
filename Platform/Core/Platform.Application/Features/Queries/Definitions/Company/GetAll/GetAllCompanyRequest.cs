using MediatR;
using Utilities.Core.UtilityApplication.RequestParameters;

namespace Platform.Application.Features.Queries.Definitions.Company.GetAll
{
    public class GetAllCompanyRequest : Pagination, IRequest<GetAllCompanyResponse>
    {
      
    }
}