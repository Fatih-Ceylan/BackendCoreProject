using GCrm.Application.Repositories.WriteRepository;
using MediatR;
using Utilities.Core.UtilityApplication.Enums;

namespace GCrm.Application.Features.Commands.Definitions.CompanyContactName.Delete
{
    public class DeleteCompanyContactNameHandler : IRequestHandler<DeleteCompanyContactNameRequest, DeleteCompanyContactNameResponse>
    {
       readonly ICompanyContactNameWriteRepository _companyContactNameWriteRepository;

        public DeleteCompanyContactNameHandler(ICompanyContactNameWriteRepository companyContactNameWriteRepository)
        {
            _companyContactNameWriteRepository = companyContactNameWriteRepository;
        }

        public async  Task<DeleteCompanyContactNameResponse> Handle(DeleteCompanyContactNameRequest request, CancellationToken cancellationToken)
        {
            await _companyContactNameWriteRepository.SoftDeleteAsync(request.Id);
            await _companyContactNameWriteRepository.SaveAsync();

            return new()
            {
                Message = CommandResponseMessage.DeletedSuccess.ToString(),
            };
        }
    }
}
