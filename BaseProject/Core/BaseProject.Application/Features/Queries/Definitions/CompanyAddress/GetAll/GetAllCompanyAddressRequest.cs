using MediatR;
using Utilities.Core.UtilityApplication.RequestParameters;

namespace BaseProject.Application.Features.Queries.Definitions.CompanyAddress.GetAll
{
    public class GetAllCompanyAddressRequest : Pagination, IRequest<GetAllCompanyAddressResponse>
    {

    }
}