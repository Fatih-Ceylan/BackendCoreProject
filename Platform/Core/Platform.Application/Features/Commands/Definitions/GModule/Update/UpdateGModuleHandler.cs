using AutoMapper;
using MediatR;
using Platform.Application.Repositories.ReadRepository.Definitions;
using Platform.Application.Repositories.WriteRepository.Definitions;
using Platform.Application.Repositories.WriteRepository.Definitions.Files;
using Platform.Application.VMs.Definitions.GModuleLicenseTypePrice;
using Utilities.Core.UtilityApplication.Abstractions.Services.Storage;
using T = Platform.Domain.Entities.Definitions;

namespace Platform.Application.Features.Commands.Definitions.GModule.Update
{
    public class UpdateGModuleHandler : IRequestHandler<UpdateGModuleRequest, UpdateGModuleResponse>
    {
        readonly IStorageService _storageService;
        readonly IGModuleReadRepository _gModuleReadRepository;
        readonly IGModuleWriteRepository _gModuleWriteRepository;
        readonly IGModuleFileWriteRepository _gmoduleFileWriteRepository;
        readonly IGModuleLicenseTypePriceWriteRepository _gModuleLicenseTypePriceWriteRepository;
        readonly IMapper _mapper;

        public UpdateGModuleHandler(IStorageService storageService, IGModuleReadRepository gModuleReadRepository, IGModuleWriteRepository gModuleWriteRepository, IGModuleFileWriteRepository gmoduleFileWriteRepository, IGModuleLicenseTypePriceWriteRepository gModuleLicenseTypePriceWriteRepository, IMapper mapper)
        {
            _storageService = storageService;
            _gModuleReadRepository = gModuleReadRepository;
            _gModuleWriteRepository = gModuleWriteRepository;
            _gmoduleFileWriteRepository = gmoduleFileWriteRepository;
            _gModuleLicenseTypePriceWriteRepository = gModuleLicenseTypePriceWriteRepository;
            _mapper = mapper;
        }

        public async Task<UpdateGModuleResponse> Handle(UpdateGModuleRequest request, CancellationToken cancellationToken)
        {
            List<(string fileName, string pathOrContainerName)>? uploadedDatas = null;
            if (request.FileOptions != null)
                uploadedDatas = await _storageService.UploadAsync("GModule-Files", request.FileOptions);

            var gmodule = await _gModuleReadRepository.GetByIdAsync(request.Id);
            gmodule.Name = request.Name;
            gmodule.LogoPath = uploadedDatas != null ? uploadedDatas.Select(t => t.pathOrContainerName).FirstOrDefault() : gmodule.LogoPath;

            if (uploadedDatas != null)
            {
                await _gmoduleFileWriteRepository.AddRangeAsync(uploadedDatas.Select(r => new T.Files.GModuleFile()
                {
                    FileName = r.fileName,
                    Path = r.pathOrContainerName,
                    Storage = _storageService.StorageName,
                    GModules = new List<T.GModule>() { gmodule }
                }).ToList());
            }
            
            await _gModuleWriteRepository.SaveAsync();

            List<T.GModuleLicenseTypePrice> gModuleLicenseTypePrices = new();
            foreach (var item in request.GModuleLicenseTypePrices)
            {

                T.GModuleLicenseTypePrice gModuleLicenseTypePrice = new();
                gModuleLicenseTypePrice.Id = Guid.Parse(item.Id);
                gModuleLicenseTypePrice.GModuleId = gmodule.Id;
                gModuleLicenseTypePrice.LicenseTypeId = Guid.Parse(item.LicenseTypeId);
                gModuleLicenseTypePrice.Amount = item.Amount;
                gModuleLicenseTypePrice.TaxRate = item.TaxRate;
                gModuleLicenseTypePrice.AUserPriceForAMonth = item.AUserPriceForAMonth;
                gModuleLicenseTypePrice.ACompanyPriceForAMonth = item.ACompanyPriceForAMonth;
                gModuleLicenseTypePrices.Add(gModuleLicenseTypePrice);
            }

             _gModuleLicenseTypePriceWriteRepository.UpdateRange(gModuleLicenseTypePrices);
            await _gModuleLicenseTypePriceWriteRepository.SaveAsync();

            var createdResponse = _mapper.Map<UpdateGModuleResponse>(gmodule);
            createdResponse.MessageList = new();
            createdResponse.GModuleLicenseTypePrices = _mapper.Map<List<GModuleLicenseTypePriceUpdateVM>>(gModuleLicenseTypePrices);
            createdResponse.MessageList.Add("GModule Updated Success");
            createdResponse.MessageList.Add("GModule License Type Prices Updated Added Success");

            return createdResponse;
        }
    }
}