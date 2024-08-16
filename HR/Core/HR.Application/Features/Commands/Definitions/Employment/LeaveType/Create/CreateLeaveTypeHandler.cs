using AutoMapper;
using HR.Application.Repositories.WriteRepository;
using MediatR;
using Utilities.Core.UtilityApplication.Enums;

namespace HR.Application.Features.Commands.Definitions.Employment.LeaveType.Create
{
    public class CreateLeaveTypeHandler : IRequestHandler<CreateLeaveTypeRequest, CreateLeaveTypeResponse>
    {
        readonly ILeaveTypeWriteRepository _leaveTypeWriteRepository;
        readonly IMapper _mapper;

        public CreateLeaveTypeHandler(ILeaveTypeWriteRepository leaveTypeWriteRepository, IMapper mapper)
        {
            _leaveTypeWriteRepository = leaveTypeWriteRepository;
            _mapper = mapper;
        }

        public async Task<CreateLeaveTypeResponse> Handle(CreateLeaveTypeRequest request, CancellationToken cancellationToken)
        {
            var leaveType = _mapper.Map<BaseProject.Domain.Entities.HR.Employment.LeaveType>(request);

            leaveType = await _leaveTypeWriteRepository.AddAsync(leaveType);
            await _leaveTypeWriteRepository.SaveAsync();

            var createdResponse = _mapper.Map<CreateLeaveTypeResponse>(leaveType);
            createdResponse.Message = CommandResponseMessage.AddedSuccess.ToString();

            return createdResponse;
        }
    }
}
