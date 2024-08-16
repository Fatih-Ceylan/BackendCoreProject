using BaseProject.Application.Repositories.WriteRepository.Definitions;
using MediatR;
using Utilities.Core.UtilityApplication.Enums;

namespace BaseProject.Application.Features.Commands.Definitions.CompanyAddress.Delete
{
    public class DeleteCompanyAddressHandler : IRequestHandler<DeleteCompanyAddressRequest, DeleteCompanyAddressResponse>
    {
        readonly ICompanyAddressWriteRepository _companyAddressWriteRepository;

        public DeleteCompanyAddressHandler(ICompanyAddressWriteRepository companyAddressWriteRepository)
        {
            _companyAddressWriteRepository = companyAddressWriteRepository;
        }

        public async Task<DeleteCompanyAddressResponse> Handle(DeleteCompanyAddressRequest request, CancellationToken cancellationToken)
        {
            await _companyAddressWriteRepository.SoftDeleteAsync(request.Id);
            await _companyAddressWriteRepository.SaveAsync();

            return new()
            {
                Message = CommandResponseMessage.DeletedSuccess.ToString(),
            };

        }
    }
}
