using AutoMapper;
using Card.Application.Repositories.WriteRepository;
using MediatR;
using Utilities.Core.UtilityApplication.Enums;
using T = BaseProject.Domain.Entities.Card.Definitions;

namespace Card.Application.Features.Commands.Definitions.Field.Create
{
    public class CreateFieldHandler : IRequestHandler<CreateFieldRequest, CreateFieldResponse>
    {
        readonly IFieldWriteRepository _fieldWriteRepository;
        readonly IMapper _mapper;

        public CreateFieldHandler(IMapper mapper, IFieldWriteRepository fieldWriteRepository)
        {
            _mapper = mapper;
            _fieldWriteRepository = fieldWriteRepository;
        }

        public async Task<CreateFieldResponse> Handle(CreateFieldRequest request, CancellationToken cancellationToken)
        {
            T.Field field = _mapper.Map<T.Field>(request);

            await _fieldWriteRepository.AddAsync(field);
            await _fieldWriteRepository.SaveAsync();

            var createdResponse = _mapper.Map<CreateFieldResponse>(field);
            createdResponse.Message = CommandResponseMessage.AddedSuccess.ToString(); 



            return createdResponse;
        }
    }
}
