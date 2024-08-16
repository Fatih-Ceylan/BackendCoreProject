using AutoMapper;
using Card.Application.Repositories.ReadRepository;
using Card.Application.Repositories.WriteRepository;
using MediatR;
using Utilities.Core.UtilityApplication.Enums;

namespace Card.Application.Features.Commands.Definitions.StaffContact.Update
{
    public class UpdateStaffContactHandler : IRequestHandler<UpdateStaffContactRequest, UpdateStaffContactResponse>
    {
        readonly IStaffContactWriteRepository _staffContactWriteRepository;
        readonly IStaffContactReadRepository _staffContactReadRepository;
        readonly IMapper _mapper;

        public UpdateStaffContactHandler(IStaffContactWriteRepository staffContactWriteRepository, IStaffContactReadRepository staffContactReadRepository, IMapper mapper)
        {
            _staffContactWriteRepository = staffContactWriteRepository;
            _staffContactReadRepository = staffContactReadRepository;
            _mapper = mapper;
        }

        public async Task<UpdateStaffContactResponse> Handle(UpdateStaffContactRequest request, CancellationToken cancellationToken)
        {
            var contact = await _staffContactReadRepository.GetByIdAsync(request.Id);
            contact = _mapper.Map(request, contact);
            await _staffContactWriteRepository.SaveAsync();

            var updatedResponse = _mapper.Map<UpdateStaffContactResponse>(contact);
            updatedResponse.Message = CommandResponseMessage.UpdatedSuccess.ToString();

            return updatedResponse;
        }
    }
}
