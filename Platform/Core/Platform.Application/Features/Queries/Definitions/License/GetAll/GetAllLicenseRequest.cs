using MediatR;
using Utilities.Core.UtilityApplication.RequestParameters;

namespace Platform.Application.Features.Queries.Definitions.License.GetAll
{
    public class GetAllLicenseRequest : Pagination, IRequest<GetAllLicenseResponse>
    {
    }
}