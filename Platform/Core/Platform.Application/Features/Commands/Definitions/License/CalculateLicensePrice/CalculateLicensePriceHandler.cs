using AutoMapper;
using MediatR;
using Platform.Application.Repositories.ReadRepository.Definitions;
using Platform.Application.VMs.Definitions.LicenseDetail;
using Platform.Domain.Entities.Enums;
using T = Platform.Domain.Entities.Definitions;

namespace Platform.Application.Features.Commands.Definitions.License.CalculateLicensePrice
{
    public class CalculateLicensePriceHandler : IRequestHandler<CalculateLicensePriceRequest, CalculateLicensePriceResponse>
    {
        readonly ILicenseTypeReadRepository _licenseTypeReadRepository;
        readonly ILicenseReadRepository _licenseReadRepository;
        readonly ISpecialOfferReadRepository _specialOfferReadRepository;
        readonly IGModuleLicenseTypePriceReadRepository _gmoduleLicenseTypePriceReadRepository;
        readonly IMapper _mapper;

        public CalculateLicensePriceHandler(ILicenseTypeReadRepository licenseTypeReadRepository, ILicenseReadRepository licenseReadRepository, ISpecialOfferReadRepository specialOfferReadRepository, IGModuleLicenseTypePriceReadRepository gmoduleLicenseTypePriceReadRepository, IMapper mapper)
        {
            _licenseTypeReadRepository = licenseTypeReadRepository;
            _licenseReadRepository = licenseReadRepository;
            _specialOfferReadRepository = specialOfferReadRepository;
            _gmoduleLicenseTypePriceReadRepository = gmoduleLicenseTypePriceReadRepository;
            _mapper = mapper;
        }

        public async Task<CalculateLicensePriceResponse> Handle(CalculateLicensePriceRequest request, CancellationToken cancellationToken)
        {
            var gModuleLicenseTypePrice = _gmoduleLicenseTypePriceReadRepository
                              .GetWhere(gltp => gltp.GModuleId == Guid.Parse(request.GModuleId) && gltp.LicenseTypeId == Guid.Parse(request.LicenseTypeId))
                              .FirstOrDefault();
            if (gModuleLicenseTypePrice == null)
                throw new Exception("No fee is defined for the license type of this module.From the Modules page you need to define your fee.");
        

            var lastLicense = _licenseReadRepository
                                  .GetWhere(l => l.CompanyId == Guid.Parse(request.CompanyId)
                                            && l.GModuleId == Guid.Parse(request.GModuleId)
                                            && l.LicenseTypeId == Guid.Parse(request.LicenseTypeId)
                                            && l.ExpirationDate > request.StartDate)
                                  .OrderByDescending(l => l.ExpirationDate)
                                  .FirstOrDefault();
            if (lastLicense != null && LicenseStatusEnum.BaseLicense == request.LicenseStatus)
                throw new Exception($"You have a license for this module.License Id is {lastLicense.Id}.Please check.");

            var specialOffer = _specialOfferReadRepository
                               .GetWhere(so => so.GModuleId == Guid.Parse(request.GModuleId) && so.CompanyId == Guid.Parse(request.CompanyId) == so.EndDate >= DateTime.Today)
                               .OrderByDescending(so => so.EndDate)
                               .FirstOrDefault();

            List<T.LicenseDetail> licenseDetails = new();
            T.LicenseDetail licenseDetail;
            if (request.LicenseStatus == LicenseStatusEnum.BaseLicense)
            {
                var licenseType = _licenseTypeReadRepository.GetWhere(lt => lt.Id == Guid.Parse(request.LicenseTypeId)).FirstOrDefault();

                licenseDetail = new();
                licenseDetail.SpecialOfferId = specialOffer?.Id;
                licenseDetail.LicenseStatus = LicenseStatusEnum.BaseLicense;
                licenseDetail.Description = LicenseStatusEnum.Initial.ToString();
                licenseDetail.Number = 1;
                licenseDetail.UnitPrice = gModuleLicenseTypePrice.Amount * ((decimal)(specialOffer != null ? (100 - specialOffer.DiscountRate) / 100 : 1));
                licenseDetail.Amount = licenseDetail.Number * licenseDetail.UnitPrice;
                licenseDetail.TaxRate = gModuleLicenseTypePrice.TaxRate;
                licenseDetail.TotalAmount = licenseDetail.Amount * (100 + licenseDetail.TaxRate) / 100;
                licenseDetail.StartDate = request.StartDate;
                licenseDetails.Add(licenseDetail);

                if (request.TotalUserNumber > licenseType.UserNumber)
                {
                    licenseDetails.Add(SetLicenseDetail(true, (int)LicenseStatusEnum.BaseLicense, specialOffer, request, licenseType, gModuleLicenseTypePrice, 0, 0));
                }
                else if (request.TotalUserNumber < licenseType.UserNumber)
                {
                    throw new Exception("The total number of users cannot be less than or equal to the number of users defined in the license type.");
                }

                if (request.TotalCompanyNumber > licenseType.CompanyNumber)
                {
                    licenseDetails.Add(SetLicenseDetail(false, (int)LicenseStatusEnum.BaseLicense, specialOffer, request, licenseType, gModuleLicenseTypePrice, 0, 0));
                }
                else if (request.TotalCompanyNumber < licenseType.CompanyNumber)
                {
                    throw new Exception("The total number of companies cannot be less than or equal to the number of companies defined in the license type.");
                }
            }
            else if (request.LicenseStatus == LicenseStatusEnum.ExtraLicense)
            {
                if (lastLicense != null)
                {
                    var newUsageMonth = (lastLicense.ExpirationDate - request.StartDate).Days;
                    newUsageMonth = newUsageMonth / 30;
                    if (newUsageMonth < 1)
                        throw new Exception("The usage period cannot be less than 1 month!");


                    if (request.TotalUserNumber > lastLicense.TotalUserNumber)
                    {
                        licenseDetails.Add(SetLicenseDetail(true, (int)LicenseStatusEnum.ExtraLicense, specialOffer, request, null, gModuleLicenseTypePrice, newUsageMonth, lastLicense.TotalUserNumber));
                    }
                    else if (request.TotalUserNumber < lastLicense.TotalUserNumber)
                    {
                        throw new Exception("The total number of users cannot be less than or equal to the number of users defined in the active license.");
                    }

                    if (request.TotalCompanyNumber > lastLicense.TotalCompanyNumber)
                    {
                        licenseDetails.Add(SetLicenseDetail(false, (int)LicenseStatusEnum.ExtraLicense, specialOffer, request, null, gModuleLicenseTypePrice, newUsageMonth, lastLicense.TotalCompanyNumber));
                    }
                    else if (request.TotalCompanyNumber <= lastLicense.TotalCompanyNumber)
                    {
                        throw new Exception("The total number of companies cannot be less than or equal to the number of companies defined in the active license.");
                    }
                }
                else
                {
                    throw new Exception("This company does not have a basic license for this module.");
                }
            }
            else
            {
                throw new Exception("License status is not valid.");
            }

            decimal grandTotal = 0;

            if (licenseDetails != null)
            {
                foreach (var item in licenseDetails) {
                    grandTotal += item.TotalAmount;
                }
            }

            return new()
            {
                LicenseDetailsTotalAmount = grandTotal, 
                LicenseDetails = _mapper.Map<List<CreateLicenseDetailVM>>(licenseDetails),
            };
        }

        private T.LicenseDetail SetLicenseDetail(bool isUser, int status, T.SpecialOffer? specialOffer, CalculateLicensePriceRequest request, T.LicenseType? licenseType, T.GModuleLicenseTypePrice gModuleLicenseTypePrice, int newUsageMonth, int totalNumber)
        {
            T.LicenseDetail licenseDetail = new();
            licenseDetail.SpecialOfferId = specialOffer?.Id;
            licenseDetail.LicenseStatus = LicenseStatusEnum.ExtraLicense;

            licenseDetail.Description = isUser ? LicenseStatusEnum.AddedUser.ToString() 
                                               : LicenseStatusEnum.AddedCompany.ToString();

            licenseDetail.Number = (isUser ? request.TotalUserNumber 
                                           : request.TotalCompanyNumber) -
                                   (status == (int)LicenseStatusEnum.BaseLicense ? (isUser ? licenseType.UserNumber 
                                                                                           : licenseType.CompanyNumber)
                                                                                 : (totalNumber));

            var price = isUser ? gModuleLicenseTypePrice.AUserPriceForAMonth 
                               : gModuleLicenseTypePrice.ACompanyPriceForAMonth;

            var spacialOffer = (decimal)(specialOffer != null ? (100 - specialOffer.DiscountRate) / 100 
                                                              : 1);

            var usageMonth = status == (int)LicenseStatusEnum.ExtraLicense ? newUsageMonth 
                                         : licenseType.UsageMounth;

            licenseDetail.UnitPrice = price * spacialOffer * usageMonth;

            licenseDetail.Amount = licenseDetail.Number * licenseDetail.UnitPrice;
            licenseDetail.TaxRate = gModuleLicenseTypePrice.TaxRate;
            licenseDetail.TotalAmount = licenseDetail.Amount * (100 + licenseDetail.TaxRate) / 100;
            licenseDetail.StartDate = request.StartDate;

            return licenseDetail;
        }
    }
}