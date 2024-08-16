using AutoMapper;
using HR.Application.Repositories.ReadRepository;
using HR.Application.Repositories.WriteRepository;
using MediatR;
using Utilities.Core.UtilityApplication.Enums;

namespace HR.Application.Features.Commands.Definitions.Employment.Appellation.Update
{
    public class UpdateAppellationHandler : IRequestHandler<UpdateAppellationRequest, UpdateAppellationResponse>
    {
        public IMapper _mapper;
        public IAppellationReadRepository appellationReadRepository;
        public IAppellationWriteRepository appellationWriteRepository;

        public UpdateAppellationHandler(IMapper mapper, IAppellationReadRepository AppellationReadRepository, IAppellationWriteRepository AppellationWriteRepository)
        {
            _mapper = mapper;
            appellationReadRepository = AppellationReadRepository;
            appellationWriteRepository = AppellationWriteRepository;
        }

        public async Task<UpdateAppellationResponse> Handle(UpdateAppellationRequest request, CancellationToken cancellationToken)
        {
            var Appellation = await appellationReadRepository.GetByIdAsync(request.Id);
            Appellation = _mapper.Map(request, Appellation);
            await appellationWriteRepository.SaveAsync();

            var updatedResponse = _mapper.Map<UpdateAppellationResponse>(Appellation);
            updatedResponse.Message = CommandResponseMessage.UpdatedSuccess.ToString();

            return updatedResponse;
        }
    }
}
