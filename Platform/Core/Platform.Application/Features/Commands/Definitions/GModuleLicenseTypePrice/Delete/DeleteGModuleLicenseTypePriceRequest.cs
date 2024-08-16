using MediatR;

namespace Platform.Application.Features.Commands.Definitions.GModuleLicenseTypePrice.Delete
{
    public class DeleteGModuleLicenseTypePriceRequest: IRequest<DeleteGModuleLicenseTypePriceResponse>
    {
        public string Id { get; set; }
    }
}