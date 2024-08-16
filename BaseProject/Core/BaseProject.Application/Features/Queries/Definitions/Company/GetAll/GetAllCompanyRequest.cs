using MediatR;
using Utilities.Core.UtilityApplication.RequestParameters;

namespace BaseProject.Application.Features.Queries.Definitions.Company.GetAll
{
    public class GetAllCompanyRequest : Pagination, IRequest<GetAllCompanyResponse>
    {
    }
}