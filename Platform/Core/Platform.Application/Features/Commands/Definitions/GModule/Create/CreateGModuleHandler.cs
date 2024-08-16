using AutoMapper;
using MediatR;
using Platform.Application.Repositories.WriteRepository.Definitions;
using Platform.Application.Repositories.WriteRepository.Definitions.Files;
using Platform.Application.VMs.Definitions.GModuleLicenseTypePrice;
using Utilities.Core.UtilityApplication.Abstractions.Services.Storage;
using T = Platform.Domain.Entities.Definitions;

namespace Platform.Application.Features.Commands.Definitions.GModule.Create
{
    public class CreateGModuleHandler : IRequestHandler<CreateGModuleRequest, CreateGModuleResponse>
    {
        readonly IGModuleWriteRepository _gmoduleWriteRepository;
        readonly IMapper _mapper;
        readonly IStorageService _storageService;
        readonly IGModuleFileWriteRepository _gmoduleFileWriteRepository;
        readonly IGModuleLicenseTypePriceWriteRepository _gmoduleLicenseTypePriceWriteRepository;

        public CreateGModuleHandler(IGModuleWriteRepository gmoduleWriteRepository, IMapper mapper, IStorageService storageService, IGModuleFileWriteRepository gmoduleFileWriteRepository, IGModuleLicenseTypePriceWriteRepository gmoduleLicenseTypePriceWriteRepository)
        {
            _gmoduleWriteRepository = gmoduleWriteRepository;
            _mapper = mapper;
            _storageService = storageService;
            _gmoduleFileWriteRepository = gmoduleFileWriteRepository;
            _gmoduleLicenseTypePriceWriteRepository = gmoduleLicenseTypePriceWriteRepository;
        }

        public async Task<CreateGModuleResponse> Handle(CreateGModuleRequest request, CancellationToken cancellationToken)
        {
            List<(string fileName, string pathOrContainerName)>? uploadedDatas = null;
            if (request.FileOptions != null)
                uploadedDatas = await _storageService.UploadAsync("GModule-Files", request.FileOptions);

            T.GModule gmodule = new();
            gmodule.Name = request.Name;
            gmodule.LogoPath = uploadedDatas != null ? uploadedDatas.Select(t => t.pathOrContainerName).FirstOrDefault() : null;
            gmodule = await _gmoduleWriteRepository.AddAsync(gmodule);

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
            await _gmoduleWriteRepository.SaveAsync();

            List<T.GModuleLicenseTypePrice> gModuleLicenseTypePrices = new();
            foreach (var item in request.GModuleLicenseTypePrices)
            {

                T.GModuleLicenseTypePrice gModuleLicenseTypePrice = new();
                gModuleLicenseTypePrice.GModuleId = gmodule.Id;
                gModuleLicenseTypePrice.LicenseTypeId = Guid.Parse(item.LicenseTypeId);
                gModuleLicenseTypePrice.Amount = item.Amount;
                gModuleLicenseTypePrice.TaxRate = item.TaxRate;
                gModuleLicenseTypePrice.AUserPriceForAMonth = item.AUserPriceForAMonth;
                gModuleLicenseTypePrice.ACompanyPriceForAMonth = item.ACompanyPriceForAMonth;
                gModuleLicenseTypePrices.Add(gModuleLicenseTypePrice);
            }

            await _gmoduleLicenseTypePriceWriteRepository.AddRangeAsync(gModuleLicenseTypePrices);
            await _gmoduleLicenseTypePriceWriteRepository.SaveAsync();

            var createdResponse = _mapper.Map<CreateGModuleResponse>(gmodule);
            createdResponse.MessageList = new();
            createdResponse.GModuleLicenseTypePrices = _mapper.Map<List<GModuleLicenseTypePriceCreateVM>>(gModuleLicenseTypePrices);
            createdResponse.MessageList.Add("GModule Added Success");
            createdResponse.MessageList.Add("GModule License Type Prices Added Success");

            return createdResponse;
        }
    }
}