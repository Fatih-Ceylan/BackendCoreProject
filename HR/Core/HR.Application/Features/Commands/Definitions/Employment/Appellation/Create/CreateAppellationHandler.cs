using AutoMapper;
using HR.Application.Repositories.WriteRepository;
using MediatR;
using Utilities.Core.UtilityApplication.Enums;
using T = BaseProject.Domain.Entities.HR.Employment;

namespace HR.Application.Features.Commands.Definitions.Employment.Appellation.Create
{
    public class CreateAppellationHandler : IRequestHandler<CreateAppellationRequest, CreateAppellationResponse>
    {
        readonly IAppellationWriteRepository _appellationWriteRepository;
        readonly IMapper _mapper;

        public CreateAppellationHandler(IAppellationWriteRepository appellationWriteRepository, IMapper mapper)
        {
            _appellationWriteRepository = appellationWriteRepository;
            _mapper = mapper;
        }

        public async Task<CreateAppellationResponse> Handle(CreateAppellationRequest request, CancellationToken cancellationToken)
        {
            var appellation = _mapper.Map<T.Appellation>(request);

            appellation = await _appellationWriteRepository.AddAsync(appellation);
            await _appellationWriteRepository.SaveAsync();

            var createdResponse = _mapper.Map<CreateAppellationResponse>(appellation);
            createdResponse.Message = CommandResponseMessage.AddedSuccess.ToString();

            return createdResponse;
        }
    }
}
