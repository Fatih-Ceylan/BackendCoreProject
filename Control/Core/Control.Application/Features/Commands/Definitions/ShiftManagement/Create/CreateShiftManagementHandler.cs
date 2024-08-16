using AutoMapper;
using GControl.Application.Repositories.ReadRepository;
using GControl.Application.Repositories.WriteRepository;
using MediatR;
using T = BaseProject.Domain.Entities.GControl.Definitions;

namespace GControl.Application.Features.Commands.Definitions.ShiftManagement.Create
{
    public class CreateShiftManagementHandler : IRequestHandler<CreateShiftManagementRequest, CreateShiftManagementResponse>
    {
        readonly IShiftManagementWriteRepository _shiftManagementWriteRepository;
        readonly IShiftManagementReadRepository _shiftManagementReadRepository;
        readonly IMapper _mapper;
        readonly BaseProject.Application.Repositories.ReadRepository.Definitions.ICompanyReadRepository _companyReadRepository;

        public CreateShiftManagementHandler(IShiftManagementWriteRepository shiftManagementWriteRepository, IShiftManagementReadRepository shiftManagementReadRepository, IMapper mapper, BaseProject.Application.Repositories.ReadRepository.Definitions.ICompanyReadRepository companyReadRepository)
        {
            _shiftManagementWriteRepository = shiftManagementWriteRepository;
            _shiftManagementReadRepository = shiftManagementReadRepository;
            _mapper = mapper;
            _companyReadRepository = companyReadRepository;
        }

        public async Task<CreateShiftManagementResponse> Handle(CreateShiftManagementRequest request, CancellationToken cancellationToken)
        {
            if (request.CompanyId == "SelectAll")
            {
                request.CompanyId = null;
            }
            // İstekten gelen veriyi kullanarak yeni bir ShiftManagement oluştur
            var shiftManagement = _mapper.Map<T.ShiftManagement>(request);

            if (string.IsNullOrEmpty(request.CompanyId) || request.CompanyId == "SelectAll")
            {
                var mainCompanyId = _companyReadRepository.GetWhere(x => x.MainCompanyId == null).FirstOrDefault().Id;
                shiftManagement.CompanyId = mainCompanyId;
            }
            // Başlangıç tarihinin bitiş tarihinden önce olup olmadığını kontrol et
            if (shiftManagement.ShiftStartDate >= shiftManagement.ShiftEndDate)
            {
                // Hatalı durum, uygun bir cevap döndür
                var errorResponse = new CreateShiftManagementResponse
                {
                    Message = "Başlangıç tarihi, bitiş tarihinden önce olmalıdır.",
                    StatusCode = 400 // Bad Request
                };

                return errorResponse;
            }

            // ShiftManagement listesini, belirtilen başlangıç tarihi ve günlerle eşleşen kayıtları al
            var existingShifts = _shiftManagementReadRepository
                .GetAllDeletedStatusDesc(false)
                .Where(ds => ds.ShiftStartDate <= shiftManagement.ShiftEndDate && ds.ShiftEndDate >= shiftManagement.ShiftStartDate &&
                             ds.Monday == shiftManagement.Monday &&
                             ds.Tuesday == shiftManagement.Tuesday &&
                             ds.Wednesday == shiftManagement.Wednesday &&
                             ds.Thursday == shiftManagement.Thursday &&
                             ds.Friday == shiftManagement.Friday &&
                             ds.Saturday == shiftManagement.Saturday &&
                             ds.Sunday == shiftManagement.Sunday)
                .ToList();

            // Eğer böyle bir kayıt varsa, mevcut olanı döndür
            if (existingShifts.Any())
            {
                var existingShift = existingShifts.First(); // veya uygun bir yöntemle mevcut kayıtlar arasından seçim yapın

                var existingShiftResponse = _mapper.Map<CreateShiftManagementResponse>(existingShift);
                existingShiftResponse.Message = "Bu mesai zaten var.";
                existingShiftResponse.StatusCode = 400;

                return existingShiftResponse;
            }

            // Eğer böyle bir kayıt yoksa, yeni kaydı ekleyin ve yanıtı hazırlayın
            shiftManagement = await _shiftManagementWriteRepository.AddAsync(shiftManagement);
            await _shiftManagementWriteRepository.SaveAsync();

            var createdResponse = _mapper.Map<CreateShiftManagementResponse>(shiftManagement);
            createdResponse.Message = "Ekleme başarılı.";
            createdResponse.StatusCode = 200; // OK

            return createdResponse;
        }
    }
}





