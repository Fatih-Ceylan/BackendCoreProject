using AutoMapper;
using BaseProject.Application.Repositories.WriteRepository.Identity;
using MediatR;
using Utilities.Core.UtilityApplication.Enums;
using T = BaseProject.Domain.Entities.Identity;

namespace BaseProject.Application.Features.Commands.Identity.AppUserAppellation.Create
{
    public class CreateAppUserAppellationHandler : IRequestHandler<CreateAppUserAppellationRequest, CreateAppUserAppellationResponse>
    {
        readonly IMapper _mapper;
        readonly IAppUserAppellationWriteRepository _appUserAppellationWriteRepository;

        public CreateAppUserAppellationHandler(IMapper mapper, IAppUserAppellationWriteRepository appUserAppellationWriteRepository)
        {
            _mapper = mapper;
            _appUserAppellationWriteRepository = appUserAppellationWriteRepository;
        }

        public async Task<CreateAppUserAppellationResponse> Handle(CreateAppUserAppellationRequest request, CancellationToken cancellationToken)
        {
            T.AppUserAppellation appUserAppellation = _mapper.Map<T.AppUserAppellation>(request);

            appUserAppellation = await _appUserAppellationWriteRepository.AddAsync(appUserAppellation);
            await _appUserAppellationWriteRepository.SaveAsync();

            var createdResponse = _mapper.Map<CreateAppUserAppellationResponse>(appUserAppellation);
            createdResponse.Message = CommandResponseMessage.AddedSuccess.ToString();

            return createdResponse;
        }
    }
}
