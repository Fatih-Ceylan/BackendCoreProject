using AutoMapper;
using GCrm.Application.Repositories.ReadRepository;
using GCrm.Application.Repositories.WriteRepository;
using MediatR;
using Utilities.Core.UtilityApplication.Enums;

namespace GCrm.Application.Features.Commands.Definitions.OpportunitySector.Update
{
    public class UpdateOpportunitySectorHandler : IRequestHandler<UpdateOpportunitySectorRequest, UpdateOpportunitySectorResponse>
    {
        readonly IOpportunitySectorWriteRepository  _opportunitySectorWriteRepository;
        readonly IOpportunitySectorReadRepository  _opportunitySectorReadRepository;
        readonly IMapper _mapper;

        public UpdateOpportunitySectorHandler(IOpportunitySectorWriteRepository opportunitySectorWriteRepository, IOpportunitySectorReadRepository opportunitySectorReadRepository, IMapper mapper)
        {
            _opportunitySectorWriteRepository = opportunitySectorWriteRepository;
            _opportunitySectorReadRepository = opportunitySectorReadRepository;
            _mapper = mapper;
        }

        public async  Task<UpdateOpportunitySectorResponse> Handle(UpdateOpportunitySectorRequest request, CancellationToken cancellationToken)
        {
            var opportunitysector = await _opportunitySectorReadRepository.GetByIdAsync(request.Id);
            opportunitysector = _mapper.Map(request, opportunitysector);
            await _opportunitySectorWriteRepository.SaveAsync();

            var updatedResponse = _mapper.Map<UpdateOpportunitySectorResponse>(opportunitysector);
            updatedResponse.Message = CommandResponseMessage.UpdatedSuccess.ToString();

            return updatedResponse;
        }
    }
}
