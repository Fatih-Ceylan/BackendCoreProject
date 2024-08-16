using AutoMapper;
using GCrm.Application.Repositories.ReadRepository;
using GCrm.Application.Repositories.WriteRepository;
using MediatR;
using Utilities.Core.UtilityApplication.Enums;

namespace GCrm.Application.Features.Commands.Definitions.CompanyOffer.Update
{
    public class UpdateCompanyOfferHandler : IRequestHandler<UpdateCompanyOfferRequest, UpdateCompanyOfferResponse>
    {
        readonly ICompanyOfferWriteRepository _companyOfferWriteRepository;
        readonly ICompanyOfferReadRepository _companyOfferReadRepository;
        readonly IMapper _mapper;

        public UpdateCompanyOfferHandler(ICompanyOfferWriteRepository companyOfferWriteRepository, ICompanyOfferReadRepository companyOfferReadRepository, IMapper mapper)
        {
            _companyOfferWriteRepository = companyOfferWriteRepository;
            _companyOfferReadRepository = companyOfferReadRepository;
            _mapper = mapper;
        }

        public async  Task<UpdateCompanyOfferResponse> Handle(UpdateCompanyOfferRequest request, CancellationToken cancellationToken)
        {
            var companyoffer = await _companyOfferReadRepository.GetByIdAsync(request.Id);
            companyoffer = _mapper.Map(request, companyoffer);
            await _companyOfferWriteRepository.SaveAsync();

            var updatedResponse = _mapper.Map<UpdateCompanyOfferResponse>(companyoffer);
            updatedResponse.Message = CommandResponseMessage.UpdatedSuccess.ToString();

            return updatedResponse;
        }
    }
}
