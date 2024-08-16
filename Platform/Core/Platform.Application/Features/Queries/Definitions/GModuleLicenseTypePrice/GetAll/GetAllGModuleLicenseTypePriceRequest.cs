using MediatR;
using Utilities.Core.UtilityApplication.RequestParameters;

namespace Platform.Application.Features.Queries.Definitions.GModuleLicenseTypePrice.GetAll
{
    public class GetAllGModuleLicenseTypePriceRequest:Pagination, IRequest<GetAllGModuleLicenseTypePriceResponse>
    {
    }
}