using AutoMapper;
using Card.Application.Repositories.WriteRepository;
using MediatR;
using Utilities.Core.UtilityApplication.Enums;
using T = BaseProject.Domain.Entities.Card.Definitions;

namespace Card.Application.Features.Commands.Definitions.Cargo.Create
{
    public class CreateCargoHandler : IRequestHandler<CreateCargoRequest, CreateCargoResponse>
    {
        readonly ICargoWriteRepository _cargoWriteRepository;
        readonly IMapper _mapper;

        public CreateCargoHandler(ICargoWriteRepository cargoWriteRepository, IMapper mapper)
        {
            _cargoWriteRepository = cargoWriteRepository;
            _mapper = mapper;
        }

        public async Task<CreateCargoResponse> Handle(CreateCargoRequest request, CancellationToken cancellationToken)
        {
            T.Cargo cargo = _mapper.Map<T.Cargo>(request);

            await _cargoWriteRepository.AddAsync(cargo);
            await _cargoWriteRepository.SaveAsync();

            var createdResponse = _mapper.Map<CreateCargoResponse>(cargo);
            createdResponse.Message = CommandResponseMessage.AddedSuccess.ToString();

            return createdResponse; ;
        }
    }
}
