using AutoMapper;
using GControl.Application.Repositories.ReadRepository;
using GControl.Application.Repositories.WriteRepository;
using MediatR;
using Utilities.Core.UtilityApplication.Enums;

namespace GControl.Application.Features.Commands.Definitions.Location.Update
{
    public class UpdateLocationHandler : IRequestHandler<UpdateLocationRequest, UpdateLocationResponse>
    {
        readonly ILocationWriteRepository _locationWriteRepository;
        readonly ILocationReadRepository _locationReadRepository;
        readonly IMapper _mapper;

        public UpdateLocationHandler(ILocationWriteRepository locationWriteRepository, ILocationReadRepository locationReadRepository, IMapper mapper)
        {
            _locationWriteRepository = locationWriteRepository;
            _locationReadRepository = locationReadRepository;
            _mapper = mapper;
        }

        public async Task<UpdateLocationResponse> Handle(UpdateLocationRequest request, CancellationToken cancellationToken)
        {
            var location = await _locationReadRepository.GetByIdAsync(request.Id);
            location = _mapper.Map(request, location);
            await _locationWriteRepository.SaveAsync();

            var updatedResponse = _mapper.Map<UpdateLocationResponse>(location);
            updatedResponse.Message = CommandResponseMessage.UpdatedSuccess.ToString();

            return updatedResponse;
        }
    }
}
