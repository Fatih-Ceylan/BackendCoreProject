using AutoMapper;
using Card.Application.Repositories.ReadRepository;
using Card.Application.Repositories.WriteRepository;
using MediatR;
using Utilities.Core.UtilityApplication.Enums;
using T = BaseProject.Domain.Entities.Card.Definitions;

namespace Card.Application.Features.Commands.Definitions.StaffContact.Create
{
    public class CreateStaffContactHandler : IRequestHandler<CreateStaffContactRequest, CreateStaffContactResponse>
    {
        readonly IStaffContactWriteRepository _staffContactWriteRepository;
        readonly IMapper _mapper;
        readonly IStaffContactReadRepository _staffContactReadRepository;

        public CreateStaffContactHandler(IStaffContactWriteRepository staffContactWriteRepository, IMapper mapper, IStaffContactReadRepository staffContactReadRepository)
        {
            _staffContactWriteRepository = staffContactWriteRepository;
            _mapper = mapper;
            _staffContactReadRepository = staffContactReadRepository;
        }

        public async Task<CreateStaffContactResponse> Handle(CreateStaffContactRequest request, CancellationToken cancellationToken)
        {
            var existingStaffContact = _staffContactReadRepository
                .GetWhere(x => x.StaffId.ToString() == request.StaffId && x.ContactId.ToString() == request.ContactId).FirstOrDefault();

            if (existingStaffContact != null)
                throw new Exception("Bu kullanıcının kişi listesinde aynı kişi mevcut!");

            var contact = _mapper.Map<T.StaffContact>(request);

            contact = await _staffContactWriteRepository.AddAsync(contact);

            await _staffContactWriteRepository.SaveAsync();

            var createdResponse = _mapper.Map<CreateStaffContactResponse>(contact);
            createdResponse.Message = CommandResponseMessage.AddedSuccess.ToString();

            return createdResponse;
        }
    }
}
