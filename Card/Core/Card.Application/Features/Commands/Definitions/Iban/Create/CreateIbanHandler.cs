using AutoMapper;
using Card.Application.Repositories.WriteRepository;
using MediatR;
using Utilities.Core.UtilityApplication.Enums;
using T = BaseProject.Domain.Entities.Card.Definitions;

namespace Card.Application.Features.Commands.Definitions.Iban.Create
{
    public class CreateIbanHandler : IRequestHandler<CreateIbanRequest, CreateIbanResponse>
    {
        readonly IIbanWriteRepository _ibanWriteRepository; 
        readonly IMapper _mapper;

        public CreateIbanHandler(IIbanWriteRepository ibanWriteRepository, IMapper mapper)
        {
            _ibanWriteRepository = ibanWriteRepository;
            _mapper = mapper; 
        }

        public async Task<CreateIbanResponse> Handle(CreateIbanRequest request, CancellationToken cancellationToken)
        {
            T.Iban iban = _mapper.Map<T.Iban>(request); 

            await _ibanWriteRepository.AddAsync(iban);
            await _ibanWriteRepository.SaveAsync();

            var createdResponse = _mapper.Map<CreateIbanResponse>(iban);
            createdResponse.Message = CommandResponseMessage.AddedSuccess.ToString();
            createdResponse.StaffId = iban.StaffId.ToString();

            return createdResponse;
        }
    }
}
