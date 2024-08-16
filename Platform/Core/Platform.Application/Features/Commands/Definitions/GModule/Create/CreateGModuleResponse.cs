using Platform.Application.VMs.Definitions.GModuleLicenseTypePrice;

namespace Platform.Application.Features.Commands.Definitions.GModule.Create
{
    public class CreateGModuleResponse
    {
        public string Id { get; set; }

        public string Name { get; set; }

        public string? LogoPath { get; set; }

        public List<GModuleLicenseTypePriceCreateVM> GModuleLicenseTypePrices { get; set; }

        public List<string> MessageList { get; set; }
    }
}