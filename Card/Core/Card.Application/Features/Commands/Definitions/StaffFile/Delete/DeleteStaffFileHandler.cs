using Card.Application.Repositories.ReadRepository;
using Card.Application.Repositories.WriteRepository;
using Card.Application.VMs;
using MediatR;
using Utilities.Core.UtilityApplication.Abstractions.Services.Storage;
using Utilities.Core.UtilityApplication.Enums;

namespace Card.Application.Features.Commands.Definitions.StaffFile.Delete
{
    public class DeleteStaffFileHandler : IRequestHandler<DeleteStaffFileRequest, DeleteStaffFileResponse>
    {
        readonly IStorageService _storageService;
        readonly IStaffFileWriteRepository _staffFileWriteRepository;
        readonly IStaffFileReadRepository _staffFileReadRepository;

        public DeleteStaffFileHandler(IStorageService storageService, IStaffFileWriteRepository staffFileWriteRepository, IStaffFileReadRepository staffFileReadRepository)
        {
            _storageService = storageService;
            _staffFileWriteRepository = staffFileWriteRepository;
            _staffFileReadRepository = staffFileReadRepository;
        }

        public async Task<DeleteStaffFileResponse> Handle(DeleteStaffFileRequest request, CancellationToken cancellationToken)
        {
            var file = _staffFileReadRepository
                           .GetWhere(c => c.Id == Guid.Parse(request.Id), false)
                           .Select(c => new StaffFileVM
                           {
                               Id = c.Id.ToString(),
                               FileName=c.FileName,
                               PathOrContainerName=c.Path,
                               Storage=c.Storage
                               
                           }).FirstOrDefault();

            var fileName = file.PathOrContainerName.Split('\\');

            await _storageService.DeleteAsync(fileName[0],file.FileName);
            await _staffFileWriteRepository.SoftDeleteAsync(request.Id);
            await _staffFileWriteRepository.SaveAsync();

            return new()
            {
                Message = CommandResponseMessage.DeletedSuccess.ToString(),
            };
        }
    }
}
