using MediatR;
using Platform.Application.VMs.Definitions.GModuleLicenseTypePrice;
using Utilities.Core.UtilityApplication.DTOs.File;

namespace Platform.Application.Features.Commands.Definitions.GModule.Create
{
    public class CreateGModuleRequest : IRequest<CreateGModuleResponse>
    {
        public List<FileOptionDTO>? FileOptions { get; set; }

        public string Name { get; set; }

        public List<GModuleLicenseTypePriceCreateVM> GModuleLicenseTypePrices { get; set; }
    }
}