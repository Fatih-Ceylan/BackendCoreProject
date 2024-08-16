using AutoMapper;
using Card.Application.Repositories.ReadRepository;
using Card.Application.Repositories.WriteRepository;
using Card.Application.VMs;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using System.Security.Cryptography;
using System.Text;
using Utilities.Core.UtilityApplication.Abstractions.Services.Storage;
using Utilities.Core.UtilityApplication.Enums;
using T = BaseProject.Domain.Entities.Card.Definitions;

namespace Card.Application.Features.Commands.Definitions.Staff.Create
{
    public class CreateStaffHandler : IRequestHandler<CreateStaffRequest, CreateStaffResponse>
    {
        readonly IStaffWriteRepository _staffWriteRepository;
        readonly IMapper _mapper;
        readonly IStorageService _storageService;
        readonly IStaffFileWriteRepository _staffFileWriteRepository;
        readonly IStaffFieldWriteRepository _staffFieldWriteRepository;
        readonly IFieldReadRepository _fieldReadRepository; 
        readonly IStaffReadRepository _staffReadRepository;
        readonly IHttpContextAccessor _httpContextAccessor;
        readonly IConfiguration _configuration;

        public CreateStaffHandler(IStaffWriteRepository customerWriteRepository, IMapper mapper, IStorageService storageService, IStaffFileWriteRepository staffFileWriteRepository, IStaffFieldWriteRepository staffFieldWriteRepository, IFieldReadRepository fieldReadRepository, IStaffReadRepository staffReadRepository, IHttpContextAccessor httpContextAccessor, IConfiguration configuration)
        {
            _staffWriteRepository = customerWriteRepository;
            _mapper = mapper;
            _storageService = storageService;
            _staffFileWriteRepository = staffFileWriteRepository;
            _staffFieldWriteRepository = staffFieldWriteRepository;
            _fieldReadRepository = fieldReadRepository;
            _staffReadRepository = staffReadRepository;
            _httpContextAccessor = httpContextAccessor;
            _configuration = configuration;
        }

        public async Task<CreateStaffResponse> Handle(CreateStaffRequest request, CancellationToken cancellationToken)
        {
            if (request.CompanyId == "SelectAll")
            {
                request.CompanyId = null;
            }
            if (request.BranchId == "SelectAll")
            {
                request.BranchId = null;
            }
            var route = _httpContextAccessor?.HttpContext?.Request?.Headers?["Route-Name"];

            var existingStaffWithEmail = await _staffReadRepository.GetByEmailAsync(request.Email);
            var existingStaffWithUsername = await _staffReadRepository.GetByUserNameAsync(request.UserName);

            if (existingStaffWithEmail != null)
                throw new Exception("Bu e-posta adresi zaten kullanımda.");
            if (existingStaffWithUsername != null)
                throw new Exception("Bu kullanıcı adı zaten kullanımda.");

            List<(string fileName, string pathOrContainerName)>? uploadedDatas = null;
            if (request.Files.Count > 0)
                uploadedDatas = await _storageService.UploadAsync("Staff-ProfilePictures", request.Files);

            T.Staff staff = _mapper.Map<T.Staff>(request);
            staff.ProfilePicturePath = uploadedDatas != null ? uploadedDatas.Select(t => t.pathOrContainerName).FirstOrDefault() : null;
            

            using (SHA256 sha256Hash = SHA256.Create())
            {
                byte[] bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(request.Password));

                StringBuilder builder = new StringBuilder();
                for (int i = 0; i < bytes.Length; i++)
                {
                    builder.Append(bytes[i].ToString("x2"));
                }
                staff.Password = builder.ToString();
            }

            staff = await _staffWriteRepository.AddAsync(staff);

            var storageURL = _configuration["Storage:BaseFrontendUrl"];
            staff.StaffUrl = $"{storageURL}{route}/Card-userqr/{staff.Id.ToString()}";

            var fields = _fieldReadRepository.GetAllDeletedStatus(false)
               .Select(c => new FieldVM
               {
                   Id = c.Id.ToString()
               }).ToList();

            List<T.StaffField> staffFields = new List<T.StaffField>();

            int rowNumber = 1;
             
            foreach (var field in fields)
            { 
                var staffField = new T.StaffField
                {
                    Id = Guid.NewGuid(),
                    FieldId = Guid.Parse(field.Id),
                    RowNumber = rowNumber, 
                    StaffId = staff.Id,
                    BranchId = staff.BranchId,
                    CompanyId = staff.CompanyId,
                };
                 
                staffFields.Add(staffField);
                 
                rowNumber++;
            }


            await _staffFieldWriteRepository.AddRangeAsync(staffFields);

            var createdResponse = _mapper.Map<CreateStaffResponse>(staff);

            if (uploadedDatas != null)
            {
                await _staffFileWriteRepository.AddRangeAsync(uploadedDatas.Select(r => new T.Files.StaffFile()
                {
                    FileName = r.fileName,
                    Path = r.pathOrContainerName,
                    Storage = _storageService.StorageName,
                    Staffs = new List<T.Staff>() { staff }
                }).ToList());
            }

            await _staffWriteRepository.SaveAsync();

            await _staffFieldWriteRepository.SaveAsync();

            createdResponse.Message = CommandResponseMessage.AddedSuccess.ToString(); 

            return createdResponse;
        }
    }
}
