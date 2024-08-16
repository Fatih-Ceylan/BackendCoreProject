using AutoMapper;
using MediatR;
using NLLogistics.Application.Repositories.WriteRepositories.Definitions;
using Utilities.Core.UtilityApplication.Enums;
using T = BaseProject.Domain.Entities.NLLogistics.Definitions;

namespace NLLogistics.Application.Features.Commands.Definitions.Vessel.Create
{
    public class CreateVesselHandler : IRequestHandler<CreateVesselRequest, CreateVesselResponse>
    {
        readonly IVesselWriteRepository _vesselWriteRepository;
        readonly IMapper _mapper;
        public CreateVesselHandler(IVesselWriteRepository vesselWriteRepository, IMapper mapper)
        {
            _vesselWriteRepository = vesselWriteRepository;
            _mapper = mapper;
        }

        public async Task<CreateVesselResponse> Handle(CreateVesselRequest request, CancellationToken cancellationToken)
        {
            var vessel = _mapper.Map<T.Vessel>(request);

            vessel = await _vesselWriteRepository.AddAsync(vessel);
            await _vesselWriteRepository.SaveAsync();

            var response = _mapper.Map<CreateVesselResponse>(vessel);
            response.Message = CommandResponseMessage.AddedSuccess.ToString();
            
            return response;
        }
    }
}