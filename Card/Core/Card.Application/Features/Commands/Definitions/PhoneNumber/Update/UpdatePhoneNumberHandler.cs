using AutoMapper;
using Card.Application.Repositories.ReadRepository;
using Card.Application.Repositories.WriteRepository;
using MediatR;
using Utilities.Core.UtilityApplication.Enums;
using T = BaseProject.Domain.Entities.Card.Definitions;

namespace Card.Application.Features.Commands.Definitions.PhoneNumber.Update
{
    public class UpdatePhoneNumberHandler : IRequestHandler<UpdatePhoneNumberRequest, UpdatePhoneNumberResponse>
    {
        readonly IPhoneNumberWriteRepository _phoneNumberWriteRepository;
        readonly IPhoneNumberReadRepository _phoneNumberReadRepository;
        readonly IMapper _mapper;

        public UpdatePhoneNumberHandler(IPhoneNumberWriteRepository phoneNumberWriteRepository, IPhoneNumberReadRepository phoneNumberReadRepository, IMapper mapper)
        {
            _phoneNumberWriteRepository = phoneNumberWriteRepository;
            _phoneNumberReadRepository = phoneNumberReadRepository;
            _mapper = mapper;
        }

        public async Task<UpdatePhoneNumberResponse> Handle(UpdatePhoneNumberRequest request, CancellationToken cancellationToken)
        {
            T.PhoneNumber phone = await _phoneNumberReadRepository.GetByIdAsync(request.Id);
            phone = _mapper.Map(request, phone);
            await _phoneNumberWriteRepository.SaveAsync();

            var updatedResponse = _mapper.Map<UpdatePhoneNumberResponse>(phone);
            updatedResponse.Message = CommandResponseMessage.UpdatedSuccess.ToString();
            updatedResponse.StaffId = phone.StaffId.ToString();

            return updatedResponse;
        }
    }
}
