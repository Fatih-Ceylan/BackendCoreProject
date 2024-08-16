using AutoMapper;
using MediatR;
using NLLogistics.Application.Repositories.ReadRepositories.Definitions;
using NLLogistics.Application.Repositories.WriteRepositories.Definitions;
using Utilities.Core.UtilityApplication.Enums;

namespace NLLogistics.Application.Features.Commands.Definitions.Vessel.Update
{
    public class UpdateVesselHandler : IRequestHandler<UpdateVesselRequest, UpdateVesselResponse>
    {
        readonly IVesselReadRepository _vesselReadRepository;
        readonly IVesselWriteRepository _vesselWriteRepository;
        readonly IMapper _mapper;

        public UpdateVesselHandler(IVesselReadRepository vesselReadRepository, IVesselWriteRepository vesselWriteRepository, IMapper mapper)
        {
            _vesselReadRepository = vesselReadRepository;
            _vesselWriteRepository = vesselWriteRepository;
            _mapper = mapper;
        }

        public async Task<UpdateVesselResponse> Handle(UpdateVesselRequest request, CancellationToken cancellationToken)
        {
            var vessel = await _vesselReadRepository.GetByIdAsync(request.Id);
            vessel = _mapper.Map(request, vessel);
            await _vesselWriteRepository.SaveAsync();

            var response = _mapper.Map<UpdateVesselResponse>(vessel);
            response.Message = CommandResponseMessage.UpdatedSuccess.ToString();

            return response;
        }
    }
}