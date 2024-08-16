using AutoMapper;
using GControl.Application.Repositories.ReadRepository;
using GControl.Application.Repositories.WriteRepository;
using MediatR;
using Utilities.Core.UtilityApplication.Enums;

namespace GControl.Application.Features.Commands.Definitions.ShiftManagement.Update
{
    public class UpdateShiftManagementHandler : IRequestHandler<UpdateShiftManagementRequest, UpdateShiftManagementResponse>
    {
        readonly IShiftManagementWriteRepository _shiftManagementWriteRepository;
        readonly IShiftManagementReadRepository _shiftManagementReadRepository;
        readonly IMapper _mapper;

        public UpdateShiftManagementHandler(IShiftManagementWriteRepository shiftManagementWriteRepository, IShiftManagementReadRepository shiftManagementReadRepository, IMapper mapper)
        {
            _shiftManagementWriteRepository = shiftManagementWriteRepository;
            _shiftManagementReadRepository = shiftManagementReadRepository;
            _mapper = mapper;
        }

        public async Task<UpdateShiftManagementResponse> Handle(UpdateShiftManagementRequest request, CancellationToken cancellationToken)
        {
            var shiftManagement = await _shiftManagementReadRepository.GetByIdAsync(request.Id);

            if (shiftManagement == null)
            {
                var notFoundResponse = new UpdateShiftManagementResponse
                {
                    Message = "Belirtilen kimlik numarasına sahip mesai yönetimi bulunamadı.",
                    StatusCode = 404 // Not Found
                };

                return notFoundResponse;
            }

            // Güncellenmiş ShiftManagement objesini haritala
            _mapper.Map(request, shiftManagement);

            // Başlangıç tarihinin bitiş tarihinden önce olup olmadığını kontrol et
            if (shiftManagement.ShiftStartDate >= shiftManagement.ShiftEndDate)
            {
                // Hatalı durum, uygun bir cevap döndür
                var errorResponse = new UpdateShiftManagementResponse
                {
                    Message = "Başlangıç tarihi, bitiş tarihinden önce olmalıdır.",
                    StatusCode = 400 // Bad Request
                };

                return errorResponse;
            }

            // Güncelleme işlemini kaydet
            await _shiftManagementWriteRepository.SaveAsync();

            var updatedResponse = _mapper.Map<UpdateShiftManagementResponse>(shiftManagement);
            updatedResponse.Message = CommandResponseMessage.UpdatedSuccess.ToString();
            updatedResponse.StatusCode = 200; // OK

            return updatedResponse;
        }
    }
}
