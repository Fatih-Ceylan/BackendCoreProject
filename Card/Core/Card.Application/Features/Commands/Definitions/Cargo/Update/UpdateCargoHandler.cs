using AutoMapper;
using Card.Application.Repositories.ReadRepository;
using Card.Application.Repositories.WriteRepository;
using MediatR;
using Utilities.Core.UtilityApplication.Enums;
using T = BaseProject.Domain.Entities.Card.Definitions;

namespace Card.Application.Features.Commands.Definitions.Cargo.Update
{
    public class UpdateCargoHandler : IRequestHandler<UpdateCargoRequest, UpdateCargoResponse>
    {
        readonly ICargoReadRepository _cargoReadRepository;
        readonly ICargoWriteRepository _cargoWriteRepository;
        readonly IMapper _mapper;

        public UpdateCargoHandler(ICargoReadRepository cargoReadRepository, ICargoWriteRepository cargoWriteRepository, IMapper mapper)
        {
            _cargoReadRepository = cargoReadRepository;
            _cargoWriteRepository = cargoWriteRepository;
            _mapper = mapper;
        }

        public async Task<UpdateCargoResponse> Handle(UpdateCargoRequest request, CancellationToken cancellationToken)
        {
            T.Cargo cargo = await _cargoReadRepository.GetByIdAsync(request.Id);
            cargo = _mapper.Map(request, cargo);
            await _cargoWriteRepository.SaveAsync();

            var updatedResponse = _mapper.Map<UpdateCargoResponse>(cargo);
            updatedResponse.Message = CommandResponseMessage.UpdatedSuccess.ToString();

            return updatedResponse;
        }
    }
}
