using AutoMapper;
using HR.Application.Repositories.ReadRepository;
using HR.Application.Repositories.WriteRepository;
using MediatR;
using Utilities.Core.UtilityApplication.Enums;

namespace HR.Application.Features.Commands.Definitions.Employment.Leave.Update
{
    public class UpdateLeaveHandler : IRequestHandler<UpdateLeaveRequest, UpdateLeaveResponse>
    {
        public IMapper _mapper;
        public ILeaveReadRepository leaveReadRepository;
        public ILeaveWriteRepository leaveWriteRepository;

        public UpdateLeaveHandler(IMapper mapper, ILeaveReadRepository LeaveReadRepository, ILeaveWriteRepository LeaveWriteRepository)
        {
            _mapper = mapper;
            leaveReadRepository = LeaveReadRepository;
            leaveWriteRepository = LeaveWriteRepository;
        }

        public async Task<UpdateLeaveResponse> Handle(UpdateLeaveRequest request, CancellationToken cancellationToken)
        {
            var leave = await leaveReadRepository.GetByIdAsync(request.Id);

            leave = _mapper.Map(request, leave);
            await leaveWriteRepository.SaveAsync();

            var updatedResponse = _mapper.Map<UpdateLeaveResponse>(leave);
            updatedResponse.Message = CommandResponseMessage.UpdatedSuccess.ToString();

            return updatedResponse;
        }
    }
}
