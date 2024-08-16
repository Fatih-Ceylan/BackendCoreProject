using MediatR;

namespace Platform.Application.Features.Queries.Definitions.GModuleLicenseTypePrice.GetById
{
    public class GetByIdGModuleLicenseTypePriceRequest: IRequest<GetByIdGModuleLicenseTypePriceResponse>
    {
        public string Id { get; set; }
    }
}