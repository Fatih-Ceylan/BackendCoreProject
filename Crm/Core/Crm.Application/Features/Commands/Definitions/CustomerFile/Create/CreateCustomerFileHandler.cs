using GCrm.Application.Repositories.ReadRepository;
using GCrm.Application.Repositories.ReadRepository.Files;
using GCrm.Application.Repositories.WriteRepository;
using GCrm.Application.Repositories.WriteRepository.Files;
using MediatR;
using Utilities.Core.UtilityApplication.Enums;

namespace GCrm.Application.Features.Commands.Definitions.CustomerFile.Create
{
    public class CreateCustomerFileHandler : IRequestHandler<CreateCustomerFileRequest, CreateCustomerFileResponse>
    {
        readonly ICustomerFileReadRepository _customerFileReadRepository;
        readonly ICustomerFileWriteRepository _customerFileWriteRepository;
        readonly ICustomerWriteRepository _customerWriteRepository;
        readonly ICustomerReadRepository _customerReadRepository;
        //readonly IStorageService _storageService; //program.cs'e referans olarakeklenecek.

        public CreateCustomerFileHandler(ICustomerFileReadRepository customerFileReadRepository, ICustomerFileWriteRepository customerFileWriteRepository, ICustomerWriteRepository customerWriteRepository,/* IStorageService storageService,*/ ICustomerReadRepository customerReadRepository)
        {
            _customerFileReadRepository = customerFileReadRepository;
            _customerFileWriteRepository = customerFileWriteRepository;
            _customerWriteRepository = customerWriteRepository;
            //_storageService = storageService;
            _customerReadRepository = customerReadRepository;
        }

        public async Task<CreateCustomerFileResponse> Handle(CreateCustomerFileRequest request, CancellationToken cancellationToken)
        {
            //var uploadedFile = await _storageService.UploadAsync("Customer-Files", request.File);
            //T.Customer customer = await _customerReadRepository.GetByIdAsync(request.Id);

            //await _customerFileWriteRepository.AddRangeAsync(uploadedFile.Select(r => new T.Files.CustomerFile()
            //{
            //    FileName = r.fileName,
            //    Path = r.pathOrContainerName,
            //    Storage = _storageService.StorageName,
            //    Customer = new List<T.Customer>() { customer },
            //}).ToList());

            //await _customerWriteRepository.SaveAsync();

            return new()
            {
                Message = CommandResponseMessage.AddedSuccess.ToString()
            };

        }
    }
}
