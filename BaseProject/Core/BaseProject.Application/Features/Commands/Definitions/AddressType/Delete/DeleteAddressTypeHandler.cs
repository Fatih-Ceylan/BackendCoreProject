using BaseProject.Application.Repositories.ReadRepository.Definitions;
using BaseProject.Application.Repositories.WriteRepository.Definitions;
using MediatR;
using Utilities.Core.UtilityApplication.Enums;

namespace BaseProject.Application.Features.Commands.Definitions.AddressType.Delete
{
    public class DeleteAddressTypeHandler : IRequestHandler<DeleteAddressTypeRequest, DeleteAddressTypeResponse>
    {
        readonly IAddressTypeWriteRepository _addressTypeWriteRepository;
        readonly ICompanyAddressReadRepository _companyAddressReadRepository;
        readonly ICompanyAddressWriteRepository _companyAddressWriteRepository;

        public DeleteAddressTypeHandler(IAddressTypeWriteRepository addressTypeWriteRepository, ICompanyAddressReadRepository companyAddressReadRepository, ICompanyAddressWriteRepository companyAddressWriteRepository)
        {
            _addressTypeWriteRepository = addressTypeWriteRepository;
            _companyAddressReadRepository = companyAddressReadRepository;
            _companyAddressWriteRepository = companyAddressWriteRepository;
        }

        public async Task<DeleteAddressTypeResponse> Handle(DeleteAddressTypeRequest request, CancellationToken cancellationToken)
        {
            await _addressTypeWriteRepository.SoftDeleteAsync(request.Id);
            await _addressTypeWriteRepository.SaveAsync();

            var companyAddresses = _companyAddressReadRepository.GetAll().Where(ca => ca.AddressTypeId == Guid.Parse(request.Id)).ToList();
            _companyAddressWriteRepository.SoftDeleteRange(companyAddresses);
            await _companyAddressWriteRepository.SaveAsync();

            return new()
            {
                Message = CommandResponseMessage.DeletedSuccess.ToString(),
            };
        }
    }
}