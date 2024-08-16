using BaseProject.Application.Repositories.WriteRepository.Definitions;
using MediatR;
using Utilities.Core.UtilityApplication.Enums;
using T = BaseProject.Domain.Entities.Definitions;

namespace BaseProject.Application.Features.Commands.Definitions.AddressType.Create
{
    public class CreateAddressTypeHandler : IRequestHandler<CreateAddressTypeRequest, CreateAddressTypeResponse>
    {
        readonly IAddressTypeWriteRepository _addressTypeWriteRepository;

        public CreateAddressTypeHandler(IAddressTypeWriteRepository addressTypeWriteRepository)
        {
            _addressTypeWriteRepository = addressTypeWriteRepository;
        }

        public async Task<CreateAddressTypeResponse> Handle(CreateAddressTypeRequest request, CancellationToken cancellationToken)
        {
            T.AddressType addressType = new();
            addressType.Name = request.Name;

            addressType = await _addressTypeWriteRepository.AddAsync(addressType);
            await _addressTypeWriteRepository.SaveAsync();

            return new()
            {
                Id = addressType.Id.ToString(),
                Name = addressType.Name,
                Message = CommandResponseMessage.AddedSuccess.ToString()
            };
        }
    }
}