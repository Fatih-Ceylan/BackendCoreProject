using MediatR;
using Platform.Application.Repositories.ReadRepository.Definitions;
using Platform.Application.VMs.Definitions.GModule;
using Platform.Application.VMs.Definitions.GModuleLicenseTypePrice;

namespace Platform.Application.Features.Queries.Definitions.GModule.GetById
{
    public class GetByIdGModuleHandler : IRequestHandler<GetByIdGModuleRequest, GetByIdGModuleResponse>
    {
        readonly IGModuleReadRepository _gmoduleReadRepository;
        readonly IGModuleLicenseTypePriceReadRepository _gmoduleLicenseTypePriceReadRepository;

        public GetByIdGModuleHandler(IGModuleReadRepository gmoduleReadRepository, IGModuleLicenseTypePriceReadRepository gmoduleLicenseTypePriceReadRepository)
        {
            _gmoduleReadRepository = gmoduleReadRepository;
            _gmoduleLicenseTypePriceReadRepository = gmoduleLicenseTypePriceReadRepository;
        }

        public async Task<GetByIdGModuleResponse> Handle(GetByIdGModuleRequest request, CancellationToken cancellationToken)
        {
            var gmodule = _gmoduleReadRepository
                         .GetWhere(ck => ck.Id == Guid.Parse(request.Id), false)
                         .Select(gm => new GModuleVM
                         {
                             Id = gm.Id.ToString(),
                             Name = gm.Name,
                             LogoPath = gm.LogoPath,
                             CreatedDate = gm.CreatedDate,
                         }).FirstOrDefault();

            var gmoduleLicenseTypePrices = _gmoduleLicenseTypePriceReadRepository.GetAllDeletedStatusDesc(false)
                .Where(gltp => gltp.GModuleId == Guid.Parse(request.Id))
                .Select(gltp => new GModuleLicenseTypePriceUpdateVM
                {
                    Id = gltp.Id.ToString(),
                    LicenseTypeId = gltp.LicenseTypeId.ToString(),
                    LicenseTypeName = gltp.LicenseType.Name,
                    LicenseTypeUsageMounth = gltp.LicenseType.UsageMounth,
                    LicenseTypeUserNumber = gltp.LicenseType.UserNumber,
                    LicenseTypeCompanyNumber = gltp.LicenseType.CompanyNumber,
                    Amount = gltp.Amount,
                    TaxRate = gltp.TaxRate,
                    AUserPriceForAMonth = gltp.AUserPriceForAMonth,
                    ACompanyPriceForAMonth = gltp.ACompanyPriceForAMonth,
                }).ToList();

            return new()
            {
                GModule = gmodule,
                GModuleLicenseTypePrices = gmoduleLicenseTypePrices
            };
        }
    }
}