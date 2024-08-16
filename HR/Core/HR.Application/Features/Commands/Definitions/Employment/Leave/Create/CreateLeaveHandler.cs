using AutoMapper;
using HR.Application.Repositories.WriteRepository;
using MediatR;
using Utilities.Core.UtilityApplication.Enums;

namespace HR.Application.Features.Commands.Definitions.Employment.Leave.Create
{
    public class CreateLeaveHandler : IRequestHandler<CreateLeaveRequest, CreateLeaveResponse>
    {
        readonly ILeaveWriteRepository _leaveWriteRepository;
        readonly IMapper _mapper;

        public CreateLeaveHandler(ILeaveWriteRepository LeaveWriteRepository, IMapper mapper)
        {
            _leaveWriteRepository = LeaveWriteRepository;
            _mapper = mapper;
        }

        public async Task<CreateLeaveResponse> Handle(CreateLeaveRequest request, CancellationToken cancellationToken)
        {
            var leave = _mapper.Map<BaseProject.Domain.Entities.HR.Employment.Leave>(request);
            leave = await _leaveWriteRepository.AddAsync(leave);
            await _leaveWriteRepository.SaveAsync();

            var createdResponse = _mapper.Map<CreateLeaveResponse>(leave);
            createdResponse.Message = CommandResponseMessage.AddedSuccess.ToString();

            return createdResponse;
        }
    }
}
