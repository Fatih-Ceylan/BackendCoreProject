using BaseProject.Application.Repositories.ReadRepository.Definitions;
using BaseProject.Application.Repositories.WriteRepository.Definitions;
using MediatR;
using Utilities.Core.UtilityApplication.Enums;

namespace BaseProject.Application.Features.Commands.Definitions.AddressType.Update
{
    public class UpdateAddressTypeHandler : IRequestHandler<UpdateAddressTypeRequest, UpdateAddressTypeResponse>
    {
        readonly IAddressTypeReadRepository _addressTypeReadRepository;
        readonly IAddressTypeWriteRepository _addressTypeWriteRepository;

        public UpdateAddressTypeHandler(IAddressTypeReadRepository addressTypeReadRepository, IAddressTypeWriteRepository addressTypeWriteRepository)
        {
            _addressTypeReadRepository = addressTypeReadRepository;
            _addressTypeWriteRepository = addressTypeWriteRepository;
        }

        public async Task<UpdateAddressTypeResponse> Handle(UpdateAddressTypeRequest request, CancellationToken cancellationToken)
        {
            var addressType = await _addressTypeReadRepository.GetByIdAsync(request.Id);
            addressType.Name = request.Name;

            await _addressTypeWriteRepository.SaveAsync();

            return new()
            {
                Id = addressType.Id.ToString(),
                Name = addressType.Name,
                Message = CommandResponseMessage.UpdatedSuccess.ToString()
            };
        }
    }
}