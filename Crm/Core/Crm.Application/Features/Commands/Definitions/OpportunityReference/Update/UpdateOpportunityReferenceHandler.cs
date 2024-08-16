using AutoMapper;
using GCrm.Application.Repositories.ReadRepository;
using GCrm.Application.Repositories.WriteRepository;
using MediatR;
using Utilities.Core.UtilityApplication.Enums;

namespace GCrm.Application.Features.Commands.Definitions.OpportunityReference.Update
{
    public class UpdateOpportunityReferenceHandler : IRequestHandler<UpdateOpportunityReferenceRequest, UpdateOpportunityReferenceResponse>
    {
        readonly IOpportunityReferenceWriteRepository  _opportunityReferenceWriteRepository;
        readonly IOpportunityReferenceReadRepository  _opportunityReferenceReadRepository;
        readonly IMapper _mapper;

        public UpdateOpportunityReferenceHandler(IOpportunityReferenceWriteRepository opportunityReferenceWriteRepository, IOpportunityReferenceReadRepository opportunityReferenceReadRepository, IMapper mapper)
        {
            _opportunityReferenceWriteRepository = opportunityReferenceWriteRepository;
            _opportunityReferenceReadRepository = opportunityReferenceReadRepository;
            _mapper = mapper;
        }

        public async  Task<UpdateOpportunityReferenceResponse> Handle(UpdateOpportunityReferenceRequest request, CancellationToken cancellationToken)
        {
            var opportunityreference = await _opportunityReferenceReadRepository.GetByIdAsync(request.Id);
            opportunityreference = _mapper.Map(request, opportunityreference);
            await _opportunityReferenceWriteRepository.SaveAsync();

            var updatedResponse = _mapper.Map<UpdateOpportunityReferenceResponse>(opportunityreference);
            updatedResponse.Message = CommandResponseMessage.UpdatedSuccess.ToString();

            return updatedResponse;
        }
    }
}
