using AutoMapper;
using GCharge.Application.Features.Commands.Definitions.UserChargeTag.Create;
using GCharge.Application.Repositories.WriteRepository.Definitions;
using MediatR;
using Utilities.Core.UtilityApplication.Enums;
using T = GCharge.Domain.Entities.Definitions;
namespace GCharge.Application.Features.Commands.Definitions.UserUserChargeTag.Create
{
    public class CreateUserChargeTagHandler : IRequestHandler<CreateUserChargeTagRequest, CreateUserChargeTagResponse>
    {
        readonly IUserChargeTagWriteRepository _userChargeTagWriteRepository;
        readonly IMapper _mapper;

        public CreateUserChargeTagHandler(IUserChargeTagWriteRepository userChargeTagWriteRepository, IMapper mapper)
        {
            _userChargeTagWriteRepository = userChargeTagWriteRepository;
            _mapper = mapper;
        }

        public async Task<CreateUserChargeTagResponse> Handle(CreateUserChargeTagRequest request, CancellationToken cancellationToken)
        {
            T.UserChargeTag chargeTag = _mapper.Map<T.UserChargeTag>(request);

            await _userChargeTagWriteRepository.AddAsync(chargeTag);
            await _userChargeTagWriteRepository.SaveAsync();

            var createdResponse = _mapper.Map<CreateUserChargeTagResponse>(chargeTag);
            createdResponse.Message = CommandResponseMessage.AddedSuccess.ToString();

            return createdResponse;
        }
    }
}
