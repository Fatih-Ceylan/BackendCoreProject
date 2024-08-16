using AutoMapper;
using HR.Application.Repositories.ReadRepository;
using HR.Application.Repositories.WriteRepository;
using MediatR;
using Utilities.Core.UtilityApplication.Enums;

namespace HR.Application.Features.Commands.Definitions.Employment.LeaveType.Update
{
    public class UpdateLeaveTypeHandler : IRequestHandler<UpdateLeaveTypeRequest, UpdateLeaveTypeResponse>
    {
        public IMapper _mapper;
        public ILeaveTypeReadRepository _leaveTypeReadRepository;
        public ILeaveTypeWriteRepository _leaveTypeWriteRepository;

        public UpdateLeaveTypeHandler(IMapper mapper, ILeaveTypeReadRepository leaveTypeReadRepository, ILeaveTypeWriteRepository leaveTypeWriteRepository)
        {
            _mapper = mapper;
            _leaveTypeReadRepository = leaveTypeReadRepository;
            _leaveTypeWriteRepository = leaveTypeWriteRepository;
        }

        public async Task<UpdateLeaveTypeResponse> Handle(UpdateLeaveTypeRequest request, CancellationToken cancellationToken)
        {
            var leaveType = await _leaveTypeReadRepository.GetByIdAsync(request.Id);
            leaveType = _mapper.Map(request, leaveType);
            await _leaveTypeWriteRepository.SaveAsync();

            var updatedResponse = _mapper.Map<UpdateLeaveTypeResponse>(leaveType);
            updatedResponse.Message = CommandResponseMessage.UpdatedSuccess.ToString();

            return updatedResponse;
        }
    }
}
