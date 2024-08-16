using AutoMapper;
using HR.Application.Repositories.WriteRepository;
using MediatR;
using Utilities.Core.UtilityApplication.Enums;

namespace HR.Application.Features.Commands.Definitions.Employment.Location.Create
{
    public class CreateLocationHandler : IRequestHandler<CreateLocationRequest, CreateLocationResponse>
    {
        readonly IMapper _mapper;
        readonly ILocationWriteRepository _locationWriteRepository;

        public CreateLocationHandler(IMapper mapper, ILocationWriteRepository locationWriteRepository)
        {
            _mapper = mapper;
            _locationWriteRepository = locationWriteRepository;
        }

        public async Task<CreateLocationResponse> Handle(CreateLocationRequest request, CancellationToken cancellationToken)
        {
            var location = _mapper.Map<BaseProject.Domain.Entities.HR.Employment.Location>(request);
            location = await _locationWriteRepository.AddAsync(location);
            await _locationWriteRepository.SaveAsync();

            var createdResponse = _mapper.Map<CreateLocationResponse>(location);
            createdResponse.Message = CommandResponseMessage.AddedSuccess.ToString();

            return createdResponse;
        }
    }
}
