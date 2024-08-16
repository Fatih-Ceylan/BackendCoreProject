using AutoMapper;
using Card.Application.Repositories.ReadRepository;
using Card.Application.Repositories.WriteRepository;
using MediatR;
using Utilities.Core.UtilityApplication.Enums;

namespace Card.Application.Features.Commands.Definitions.StaffField.Update
{
    public class UpdateStaffFieldHandler : IRequestHandler<UpdateStaffFieldRequest, UpdateStaffFieldResponse>
    {
        readonly IStaffFieldReadRepository _staffFieldReadRepository;
        readonly IStaffFieldWriteRepository _staffFieldWriteRepository;
        readonly IMapper _mapper;

        public UpdateStaffFieldHandler(IStaffFieldReadRepository staffFieldReadRepository, IStaffFieldWriteRepository staffFieldWriteRepository, IMapper mapper)
        {
            _staffFieldReadRepository = staffFieldReadRepository;
            _staffFieldWriteRepository = staffFieldWriteRepository;
            _mapper = mapper;
        }

        public async Task<UpdateStaffFieldResponse> Handle(UpdateStaffFieldRequest request, CancellationToken cancellationToken)
        {
            var staffField = await _staffFieldReadRepository.GetByIdAsync(request.Id);
            staffField = _mapper.Map(request, staffField);
            await _staffFieldWriteRepository.SaveAsync();

            var updatedResponse = _mapper.Map<UpdateStaffFieldResponse>(staffField);
            updatedResponse.Message = CommandResponseMessage.UpdatedSuccess.ToString();

            return updatedResponse;
        }
    }
}
