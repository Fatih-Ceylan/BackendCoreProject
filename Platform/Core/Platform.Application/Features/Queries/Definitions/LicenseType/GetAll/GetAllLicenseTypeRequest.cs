using MediatR;
using Utilities.Core.UtilityApplication.RequestParameters;

namespace Platform.Application.Features.Queries.Definitions.LicenseType.GetAll
{
    public class GetAllLicenseTypeRequest : Pagination, IRequest<GetAllLicenseTypeResponse>
    {

    }
}