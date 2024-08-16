using AutoMapper;
using GCrm.Application.Repositories.WriteRepository;
using MediatR;
using Utilities.Core.UtilityApplication.Enums;
using T = BaseProject.Domain.Entities.GCrm.Definitions.OpportunityManagement.Opportunity;

namespace GCrm.Application.Features.Commands.Definitions.OpportunitySector.Create
{
    public class CreateOpportunitySectorHandler : IRequestHandler<CreateOpportunitySectorRequest, CreateOpportunitySectorResponse>
    {
        readonly IOpportunitySectorWriteRepository  _opportunitySectorWriteRepository;
        readonly IMapper _mapper;

        public CreateOpportunitySectorHandler(IOpportunitySectorWriteRepository opportunitySectorWriteRepository, IMapper mapper)
        {
            _opportunitySectorWriteRepository = opportunitySectorWriteRepository;
            _mapper = mapper;
        }

        public async  Task<CreateOpportunitySectorResponse> Handle(CreateOpportunitySectorRequest request, CancellationToken cancellationToken)
        {
            var opportunitysector = _mapper.Map<T.OpportunitySector>(request);
            opportunitysector = await _opportunitySectorWriteRepository.AddAsync(opportunitysector);
            await _opportunitySectorWriteRepository.SaveAsync();

            var createdResponse = _mapper.Map<CreateOpportunitySectorResponse>(opportunitysector);
            createdResponse.Message = CommandResponseMessage.AddedSuccess.ToString();

            return createdResponse;
        }
    }
}
