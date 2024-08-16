using AutoMapper;
using Card.Application.Repositories.ReadRepository;
using Card.Application.Repositories.WriteRepository;
using MediatR;
using Utilities.Core.UtilityApplication.Enums;
using T = BaseProject.Domain.Entities.Card.Definitions;

namespace Card.Application.Features.Commands.Definitions.Field.Update
{
    public class UpdateFieldHandler : IRequestHandler<UpdateFieldRequest, UpdateFieldResponse>
    {
        readonly IFieldReadRepository _fieldReadRepository;
        readonly IFieldWriteRepository _fieldWriteRepository;
        readonly IMapper _mapper;

        public UpdateFieldHandler(IFieldReadRepository fieldReadRepository, IFieldWriteRepository fieldWriteRepository, IMapper mapper)
        {
            _fieldReadRepository = fieldReadRepository;
            _fieldWriteRepository = fieldWriteRepository;
            _mapper = mapper;
        }

        public async Task<UpdateFieldResponse> Handle(UpdateFieldRequest request, CancellationToken cancellationToken)
        {
            T.Field field = await _fieldReadRepository.GetByIdAsync(request.Id);
            field = _mapper.Map(request, field);
            await _fieldWriteRepository.SaveAsync();

            var updatedResponse = _mapper.Map<UpdateFieldResponse>(field);
            updatedResponse.Message = CommandResponseMessage.UpdatedSuccess.ToString();

            return updatedResponse;
        }
    }
}
