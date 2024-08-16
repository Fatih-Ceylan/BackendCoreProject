using AutoMapper;
using GControl.Application.Repositories.ReadRepository;
using GControl.Application.Repositories.WriteRepository;
using MediatR;
using Utilities.Core.UtilityApplication.Enums;

namespace GControl.Application.Features.Commands.Definitions.ShiftManagementIsActiveStatus
{
    public class ShiftManagementIsActiveStatusHandler : IRequestHandler<ShiftManagementIsActiveStatusRequest, ShiftManagementIsActiveStatusResponse>
    {
        readonly IShiftManagementWriteRepository _shiftManagementWriteRepository;
        readonly IShiftManagementReadRepository _shiftManagementReadRepository;
        readonly IMapper _mapper;

        public ShiftManagementIsActiveStatusHandler(IShiftManagementWriteRepository shiftManagementWriteRepository, IShiftManagementReadRepository shiftManagementReadRepository, IMapper mapper)
        {
            _shiftManagementWriteRepository = shiftManagementWriteRepository;

            _shiftManagementReadRepository = shiftManagementReadRepository;
            _mapper = mapper;
        }

        public async Task<ShiftManagementIsActiveStatusResponse> Handle(ShiftManagementIsActiveStatusRequest request, CancellationToken cancellationToken)
        {
            var shiftManagementIsActive = await _shiftManagementReadRepository.GetByIdAsync(request.Id);
            shiftManagementIsActive.isActive = request.isActive;
            _mapper.Map(request.isActive, shiftManagementIsActive.isActive);
            await _shiftManagementWriteRepository.SaveAsync();
            var updatedResponse = new ShiftManagementIsActiveStatusResponse
            {
                Id = shiftManagementIsActive.Id.ToString(),
                IsActive = shiftManagementIsActive.isActive,
                Message = CommandResponseMessage.UpdatedSuccess.ToString()
            };


            return updatedResponse;
        }
    }
}
