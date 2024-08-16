using AutoMapper;
using Card.Application.Repositories.ReadRepository;
using Card.Application.Repositories.WriteRepository;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Utilities.Core.UtilityApplication.Enums;
using T = BaseProject.Domain.Entities.Card.Definitions;


namespace Card.Application.Features.Commands.Definitions.PhoneNumber.Create
{
    public class CreatePhoneNumberHandler : IRequestHandler<CreatePhoneNumberRequest, CreatePhoneNumberResponse>
    {
        readonly IPhoneNumberWriteRepository _phoneNumberWriteRepository;
        readonly IMapper _mapper;
        readonly IPhoneNumberReadRepository _phoneNumberReadRepository;

        public CreatePhoneNumberHandler(IPhoneNumberWriteRepository phoneNumberWriteRepository, IMapper mapper, IPhoneNumberReadRepository phoneNumberReadRepository)
        {
            _phoneNumberWriteRepository = phoneNumberWriteRepository;
            _mapper = mapper;
            _phoneNumberReadRepository = phoneNumberReadRepository;
        }

        public async Task<CreatePhoneNumberResponse> Handle(CreatePhoneNumberRequest request, CancellationToken cancellationToken)
        {
            var existingPhoneNumber = await _phoneNumberReadRepository
    .GetWhere(x => x.StaffId.ToString() == request.StaffId && x.Number.ToString() == request.Number)
    .FirstOrDefaultAsync();

            if (existingPhoneNumber != null)
                throw new Exception("Bu kişinin bu numara kaydı zaten mevcut!");

            T.PhoneNumber phone = _mapper.Map<T.PhoneNumber>(request);

            await _phoneNumberWriteRepository.AddAsync(phone);
            await _phoneNumberWriteRepository.SaveAsync();

            var createdResponse = _mapper.Map<CreatePhoneNumberResponse>(phone);
            createdResponse.Message = CommandResponseMessage.AddedSuccess.ToString();
            createdResponse.StaffId = phone.StaffId.ToString();

            return createdResponse;
        }
    }
}
