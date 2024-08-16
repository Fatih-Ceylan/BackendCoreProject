using MediatR;
using Platform.Application.VMs.Definitions.GModuleLicenseTypePrice;
using Utilities.Core.UtilityApplication.DTOs.File;

namespace Platform.Application.Features.Commands.Definitions.GModule.Update
{
    public class UpdateGModuleRequest : IRequest<UpdateGModuleResponse>
    {
        public string Id { get; set; }
        
        public List<FileOptionDTO>? FileOptions { get; set; }

        public string Name { get; set; }

        public List<GModuleLicenseTypePriceUpdateVM> GModuleLicenseTypePrices { get; set; }
    }
}