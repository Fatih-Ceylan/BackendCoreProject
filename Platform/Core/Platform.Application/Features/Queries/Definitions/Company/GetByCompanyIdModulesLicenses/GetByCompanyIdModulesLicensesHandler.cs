using MediatR;
using Platform.Application.Repositories.ReadRepository.Definitions;
using Platform.Application.VMs.Definitions.GModule;
using Platform.Application.VMs.Definitions.License;
using Platform.Application.VMs.Definitions.LicenseDetail;
using Platform.Application.VMs.Definitions.SpecialOffer;

namespace Platform.Application.Features.Queries.Definitions.Company.GetByCompanyIdModulesLicenses
{
    public class GetByCompanyIdModulesLicensesHandler : IRequestHandler<GetByCompanyIdModulesLicensesRequest, GetByCompanyIdModulesLicensesResponse>
    {
        readonly IGModuleReadRepository _gModuleReadRepository;
        readonly ILicenseReadRepository _licenseReadRepository;
        readonly ILicenseDetailReadRepository _licenseDetailReadRepository;
        readonly ISpecialOfferReadRepository _specialOfferReadRepository;

        public GetByCompanyIdModulesLicensesHandler(IGModuleReadRepository gModuleReadRepository, ILicenseReadRepository licenseReadRepository, ILicenseDetailReadRepository licenseDetailReadRepository, ISpecialOfferReadRepository specialOfferReadRepository)
        {
            _gModuleReadRepository = gModuleReadRepository;
            _licenseReadRepository = licenseReadRepository;
            _licenseDetailReadRepository = licenseDetailReadRepository;
            _specialOfferReadRepository = specialOfferReadRepository;
        }

        public async Task<GetByCompanyIdModulesLicensesResponse> Handle(GetByCompanyIdModulesLicensesRequest request, CancellationToken cancellationToken)
        {
            var response = _gModuleReadRepository
                           .GetAllDeletedStatusDesc(false)
                           .Select(gm => new LicenseOfTheCompanysModuleVM
                           {
                               GModuleName = gm.Name,
                               Licenses = _licenseReadRepository
                                          .GetAllDeletedStatusDesc(false, false)
                                          .Where(l => l.CompanyId == Guid.Parse(request.Id) && l.GModuleId == gm.Id)
                                                  .Select(l => new LicenseWithLicenseDetailListVM
                                                  {
                                                      Id = l.Id.ToString(),
                                                      CompanyId = l.CompanyId.ToString(),
                                                      CompanyName = l.Company.Name,
                                                      GModuleId = l.GModuleId.ToString(),
                                                      GModuleName = l.GModule.Name,
                                                      LicenseTypeId = l.LicenseTypeId.ToString(),
                                                      LicenseTypeName = l.LicenseType.Name,
                                                      LicenseKey = l.LicenseKey.ToString(),
                                                      StartDate = l.StartDate,
                                                      ExpirationDate = l.ExpirationDate,
                                                      RemainingUsageDays = (l.ExpirationDate - DateTime.Now).Days > 0 ? (l.ExpirationDate - DateTime.Now).Days : 0,
                                                      TotalUserNumber = l.TotalUserNumber,
                                                      TotalCompanyNumber = l.TotalCompanyNumber,
                                                      CreatedDate = l.CreatedDate,
                                                      UpdatedDate = l.UpdatedDate,

                                                      LicenseDetailsTotalAmount = _licenseDetailReadRepository
                                                                                  .GetAllDeletedStatusDesc(false, false)
                                                                                  .Where(ld => ld.LicenseId == l.Id)
                                                                                  .Select(ld => ld.TotalAmount)
                                                                                  .Sum(),
                                                      LicenseDetailTaxRate = _licenseDetailReadRepository
                                                                             .GetAllDeletedStatusDesc(false, false)
                                                                             .Where(ld => ld.LicenseId == l.Id)
                                                                             .Select(ld => ld.TaxRate)
                                                                             .FirstOrDefault(),
                                                      LicenseDetails = _licenseDetailReadRepository
                                                                        .GetAllDeletedStatus(false, false).Where(ld => ld.LicenseId == l.Id)
                                                                        .Select(ld => new LicenseDetailVM
                                                                        {
                                                                            Id = ld.Id.ToString(),
                                                                            SpecialOffer = _specialOfferReadRepository
                                                                                          .GetAllDeletedStatusDesc(false, false)
                                                                                          .Where(so => so.Id == ld.SpecialOfferId)
                                                                                          .Select(so => new SpecialOfferInLicenseDetailVM
                                                                                          {
                                                                                             Id = so.Id.ToString(),
                                                                                             Description = so.Description,
                                                                                             DiscountRate = so.DiscountRate,
                                                                                             StartDate = so.StartDate,
                                                                                             EndDate = so.EndDate,
                                                                                         })
                                                                                         .FirstOrDefault(),
                                                                            LicenseStatus = ld.LicenseStatus.ToString(),
                                                                            Description = ld.Description,
                                                                            Number = ld.Number,
                                                                            UnitPrice = ld.UnitPrice,
                                                                            Amount = ld.Amount,
                                                                            TaxRate = ld.TaxRate,
                                                                            TotalAmount = ld.TotalAmount,
                                                                            StartDate = ld.StartDate,
                                                                        }).ToList()
                                                  }).ToList(),

                               LicenseCount = _licenseReadRepository.GetAllDeletedStatusDesc(false, false).Where(l => l.CompanyId == Guid.Parse(request.Id) && l.GModuleId == gm.Id).Count()
                           }).ToList();

            return new()
            {
                LicenseOfTheCompanysModules = response,
            };
        }
    }
}