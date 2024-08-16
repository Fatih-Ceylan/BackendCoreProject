using GCrm.Application.Repositories.WriteRepository;
using MediatR;
using Utilities.Core.UtilityApplication.Enums;

namespace GCrm.Application.Features.Commands.Definitions.CompanyOffer.Delete
{
    public class DeleteCompanyOfferHandler : IRequestHandler<DeleteCompanyOfferRequest, DeleteCompanyOfferResponse>
    {
        readonly ICompanyOfferWriteRepository _companyOfferWriteRepository;

        public DeleteCompanyOfferHandler(ICompanyOfferWriteRepository companyOfferWriteRepository)
        {
            _companyOfferWriteRepository = companyOfferWriteRepository;
        }

        public async Task<DeleteCompanyOfferResponse> Handle(DeleteCompanyOfferRequest request, CancellationToken cancellationToken)
        {
            await _companyOfferWriteRepository.SoftDeleteAsync(request.Id);
            await _companyOfferWriteRepository.SaveAsync();

            return new()
            {
                Message = CommandResponseMessage.DeletedSuccess.ToString(),
            };
        }
    }
}
