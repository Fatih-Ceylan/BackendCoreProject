using AutoMapper;
using Card.Application.Repositories.ReadRepository;
using Card.Application.Repositories.WriteRepository;
using MediatR;
using Utilities.Core.UtilityApplication.Enums;
using T = BaseProject.Domain.Entities.Card.Definitions;

namespace Card.Application.Features.Commands.Definitions.Address.Update
{
    public class UpdateAddressHandler : IRequestHandler<UpdateAddressRequest, UpdateAddressResponse>
    {
        readonly IAddressReadRepository _addressReadRepository;
        readonly IAddressWriteRepository _addressWriteRepository;
        readonly IMapper _mapper;

        public UpdateAddressHandler(IAddressReadRepository addressReadRepository, IAddressWriteRepository addressWriteRepository, IMapper mapper)
        {
            _addressReadRepository = addressReadRepository;
            _addressWriteRepository = addressWriteRepository;
            _mapper = mapper;
        }

        public async Task<UpdateAddressResponse> Handle(UpdateAddressRequest request, CancellationToken cancellationToken)
        {
            T.Address address = await _addressReadRepository.GetByIdAsync(request.Id);
            address = _mapper.Map(request, address);
            await _addressWriteRepository.SaveAsync();

            var updatedResponse = _mapper.Map<UpdateAddressResponse>(address);
            updatedResponse.Message = CommandResponseMessage.UpdatedSuccess.ToString();

            return updatedResponse;
        }
    }
}
