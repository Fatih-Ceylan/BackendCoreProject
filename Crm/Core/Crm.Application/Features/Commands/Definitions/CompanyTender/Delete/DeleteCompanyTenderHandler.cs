using GCrm.Application.Repositories.WriteRepository;
using MediatR;
using Utilities.Core.UtilityApplication.Enums;

namespace GCrm.Application.Features.Commands.Definitions.CompanyTender.Delete
{
    public class DeleteCompanyTenderHandler : IRequestHandler<DeleteCompanyTenderRequest, DeleteCompanyTenderResponse>
    {
        readonly ICompanyTenderWriteRepository _companyTenderWriteRepository ;

        public DeleteCompanyTenderHandler(ICompanyTenderWriteRepository companyTenderWriteRepository)
        {
            _companyTenderWriteRepository = companyTenderWriteRepository;
        }

        public async  Task<DeleteCompanyTenderResponse> Handle(DeleteCompanyTenderRequest request, CancellationToken cancellationToken)
        {
            await _companyTenderWriteRepository.SoftDeleteAsync(request.Id);
            await _companyTenderWriteRepository.SaveAsync();

            return new()
            {
                Message = CommandResponseMessage.DeletedSuccess.ToString(),
            };
        }
    }
}
