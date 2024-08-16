using AutoMapper;
using GCrm.Application.Repositories.ReadRepository;
using GCrm.Application.Repositories.WriteRepository;
using MediatR;
using Utilities.Core.UtilityApplication.Enums;

namespace GCrm.Application.Features.Commands.Definitions.Opportunity.Update
{
    public class UpdateOpportunityHandler : IRequestHandler<UpdateOpportunityRequest, UpdateOpportunityResponse>
    {
        readonly IOpportunityWriteRepository _opportunityWriteRepository;
        readonly IOpportunityReadRepository _opportunityReadRepository;
        readonly IMapper _mapper;

        public UpdateOpportunityHandler(IOpportunityWriteRepository opportunityWriteRepository, IOpportunityReadRepository opportunityReadRepository, IMapper mapper)
        {
            _opportunityWriteRepository = opportunityWriteRepository;
            _opportunityReadRepository = opportunityReadRepository;
            _mapper = mapper;
        }

        public async Task<UpdateOpportunityResponse> Handle(UpdateOpportunityRequest request, CancellationToken cancellationToken)
        {
            var opportunity = await _opportunityReadRepository.GetByIdAsync(request.Id);
            opportunity = _mapper.Map(request, opportunity);
            await _opportunityWriteRepository.SaveAsync();

            var updatedResponse = _mapper.Map<UpdateOpportunityResponse>(opportunity);
            updatedResponse.Message = CommandResponseMessage.UpdatedSuccess.ToString();

            return updatedResponse;
        }
    }
}
