using Card.Application.Repositories.ReadRepository;
using Card.Application.VMs;
using MediatR;

namespace Card.Application.Features.Queries.Definitions.StaffFile.GetById
{
    public class GetByIdStaffFileHandler : IRequestHandler<GetByIdStaffFileRequest, GetByIdStaffFileResponse>
    {
        readonly IStaffFileReadRepository _staffFileReadRepository;

        public GetByIdStaffFileHandler(IStaffFileReadRepository staffFileReadRepository)
        {
            _staffFileReadRepository = staffFileReadRepository;
        }

        public async Task<GetByIdStaffFileResponse> Handle(GetByIdStaffFileRequest request, CancellationToken cancellationToken)
        {
            var file = _staffFileReadRepository
                           .GetWhere(c => c.Id == Guid.Parse(request.Id), false)
                           .Select(c => new StaffFileVM
                           {
                               Id = c.Id.ToString(),
                               FileName = c.FileName,
                               PathOrContainerName=c.Path,
                               Storage=c.Storage,
                               //StaffId=c.StaffId.ToString()
                               
                           }).FirstOrDefault();

            return new()
            {
                File = file
            };
        }
    }
}
