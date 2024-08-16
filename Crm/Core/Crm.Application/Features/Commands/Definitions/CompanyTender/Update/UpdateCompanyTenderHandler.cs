using AutoMapper;
using GCrm.Application.Repositories.ReadRepository;
using GCrm.Application.Repositories.WriteRepository;
using MediatR;
using Utilities.Core.UtilityApplication.Enums;

namespace GCrm.Application.Features.Commands.Definitions.CompanyTender.Update
{
    public class UpdateCompanyTenderHandler : IRequestHandler<UpdateCompanyTenderRequest, UpdateCompanyTenderResponse>
    {
        readonly ICompanyTenderWriteRepository _companyTenderWriteRepository ;
        readonly ICompanyTenderReadRepository  _companyTenderReadRepository;
        readonly IMapper _mapper;
        public UpdateCompanyTenderHandler(ICompanyTenderWriteRepository companyTenderWriteRepository, ICompanyTenderReadRepository companyTenderReadRepository, IMapper mapper)
        {
            _companyTenderWriteRepository = companyTenderWriteRepository;
            _companyTenderReadRepository = companyTenderReadRepository;
            _mapper = mapper;
        }

        public async  Task<UpdateCompanyTenderResponse> Handle(UpdateCompanyTenderRequest request, CancellationToken cancellationToken)
        {
            var companyTender = await _companyTenderReadRepository.GetByIdAsync(request.Id);
            companyTender = _mapper.Map(request, companyTender);
            await _companyTenderWriteRepository.SaveAsync();

            var updatedResponse = _mapper.Map<UpdateCompanyTenderResponse>(companyTender);
            updatedResponse.Message = CommandResponseMessage.UpdatedSuccess.ToString();

            return updatedResponse;
        }
    }
}
