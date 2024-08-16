using AutoMapper;
using GCharge.Application.Abstractions.Identity;
using GCharge.Application.DTOs.Identity.AppUser;
using GCharge.Application.Repositories.WriteRepository.Definitions;
using GCharge.Domain.Entities.Definitions;
using MediatR;
using Utilities.Core.UtilityApplication.Abstractions.Services.Encryption.Sha256;
using Utilities.Core.UtilityApplication.Abstractions.Services.Storage;

namespace GCharge.Application.Features.Commands.Identity.AppUser.Create
{
    public class CreateAppUserHandler : IRequestHandler<CreateAppUserRequest, CreateAppUserResponse>
    {
        readonly IAppUserService _appUserService;
        readonly IMapper _mapper;
        readonly IStorageService _storageService;
        readonly ISha256Service _sha256Service;
        readonly IChargeTagWriteRepository _chargeTagWriteRepository;
        readonly IUserChargeTagWriteRepository _userChargeTagWriteRepository;
        public CreateAppUserHandler(IAppUserService appUserService, IMapper mapper, IStorageService storageService, ISha256Service sha256Service, IChargeTagWriteRepository chargeTagWriteRepository, IUserChargeTagWriteRepository userChargeTagWriteRepository)
        {
            _appUserService = appUserService;
            _mapper = mapper;
            _storageService = storageService;
            _sha256Service = sha256Service;
            _chargeTagWriteRepository = chargeTagWriteRepository;
            _userChargeTagWriteRepository = userChargeTagWriteRepository;
        }

        public async Task<CreateAppUserResponse> Handle(CreateAppUserRequest request, CancellationToken cancellationToken)
        {
            var appUserRequestDto = _mapper.Map<CreateUserRequestDTO>(request);
            var appUserResponseDto = await _appUserService.CreateAsync(appUserRequestDto);

            var createdResponse = _mapper.Map<CreateAppUserResponse>(appUserResponseDto);
            createdResponse.Messages = new();
            createdResponse.Messages.Add(appUserResponseDto.Message);

            string tagId = _sha256Service.GenerateUniqueCode();
            ChargeTag chargeTag = new()
            {
                TagId = tagId,
                TagName = createdResponse.Email,
                ParentTagId = tagId,
                ExpiryDate = DateTime.UtcNow.AddYears(1),
                Blocked = false
            };

            await _chargeTagWriteRepository.AddAsync(chargeTag);
            await _chargeTagWriteRepository.SaveAsync();
            createdResponse.Messages.Add("ParentTagId for User Created Successfully.");

            UserChargeTag userChargeTag = new()
            {
                UserId = createdResponse.Id,
                TagId = chargeTag.TagId,
            };

            await _userChargeTagWriteRepository.AddAsync(userChargeTag);
            await _userChargeTagWriteRepository.SaveAsync();
            createdResponse.Messages.Add("User Charge Tag Created Successfully.");


            return createdResponse;
        }
    }
}