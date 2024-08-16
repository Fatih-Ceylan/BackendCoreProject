using MediatR;
using Platform.Application.Repositories.ReadRepository.Definitions;
using Platform.Application.VMs.Definitions.GModuleLicenseTypePrice;

namespace Platform.Application.Features.Queries.Definitions.GModuleLicenseTypePrice.GetById
{
    public class GetByIdGModuleLicenseTypePriceHandler : IRequestHandler<GetByIdGModuleLicenseTypePriceRequest, GetByIdGModuleLicenseTypePriceResponse>
    {
        readonly IGModuleLicenseTypePriceReadRepository _gModuleLicenseTypePriceReadRepository;

        public GetByIdGModuleLicenseTypePriceHandler(IGModuleLicenseTypePriceReadRepository gModuleLicenseTypePriceReadRepository)
        {
            _gModuleLicenseTypePriceReadRepository = gModuleLicenseTypePriceReadRepository;
        }

        public async Task<GetByIdGModuleLicenseTypePriceResponse> Handle(GetByIdGModuleLicenseTypePriceRequest request, CancellationToken cancellationToken)
        {
            var gModuleLicenseTypePrice = _gModuleLicenseTypePriceReadRepository
                                          .GetWhere(gltp => gltp.Id == Guid.Parse(request.Id))
                                          .Select(gltp => new GModuleLicenseTypePriceVM
                                          {
                                              Id = gltp.Id.ToString(),
                                              GModuleId = gltp.GModuleId.ToString(),
                                              GModuleName = gltp.GModule.Name,
                                              LicenseTypeId = gltp.LicenseTypeId.ToString(),
                                              LicenseTypeName = gltp.LicenseType.Name,
                                              Amount = gltp.Amount,
                                              TaxRate = gltp.TaxRate,
                                              CreatedDate = gltp.CreatedDate,
                                          }).FirstOrDefault();

            return new()
            {
                GModuleLicenseTypePrice = gModuleLicenseTypePrice   
            };
        }
    }
}