using MediatR;
using Platform.Application.Repositories.ReadRepository.Definitions;
using Platform.Application.VMs.Definitions.GModuleLicenseTypePrice;

namespace Platform.Application.Features.Queries.Definitions.GModuleLicenseTypePrice.GetAll
{
    public class GetAllGModuleLicenseTypePriceHandler : IRequestHandler<GetAllGModuleLicenseTypePriceRequest, GetAllGModuleLicenseTypePriceResponse>
    {
        readonly IGModuleLicenseTypePriceReadRepository _gModuleLicenseTypePriceReadRepository;

        public GetAllGModuleLicenseTypePriceHandler(IGModuleLicenseTypePriceReadRepository gModuleLicenseTypePriceReadRepository)
        {
            _gModuleLicenseTypePriceReadRepository = gModuleLicenseTypePriceReadRepository;
        }

        public async Task<GetAllGModuleLicenseTypePriceResponse> Handle(GetAllGModuleLicenseTypePriceRequest request, CancellationToken cancellationToken)
        {
            var query = _gModuleLicenseTypePriceReadRepository
                        .GetAllDeletedStatusDesc(false, request.IsDeleted)
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
                        });

            var totalCount = query.Count();
            var gModuleLicenseTypePrices = request.DoPagination ? query.Skip(request.Page * request.Size)
                                                                       .Take(request.Size).ToList()
                                                                : query.ToList();

            return new()
            {
                TotalCount = totalCount,
                GModuleLicenseTypePrices = gModuleLicenseTypePrices
            };
        }
    }
}