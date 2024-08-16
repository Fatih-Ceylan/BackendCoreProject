using Card.Application.Repositories.ReadRepository;
using Card.Application.VMs;
using MediatR;

namespace Card.Application.Features.Queries.Definitions.StaffFile.GetFileListByStaffId
{
    public class GetFileListByStaffIdHandler : IRequestHandler<GetFileListByStaffIdRequest, GetFileListByStaffIdResponse>
    {
        readonly IStaffFileReadRepository _staffFileReadRepository;

        public GetFileListByStaffIdHandler(IStaffFileReadRepository staffFileReadRepository)
        {
            _staffFileReadRepository = staffFileReadRepository;
        }

        public Task<GetFileListByStaffIdResponse> Handle(GetFileListByStaffIdRequest request, CancellationToken cancellationToken)
        {
            var files = _staffFileReadRepository
                           .GetWhere(c => c.Id == Guid.Parse(request.Id), false)
                           .Select(c => new StaffFileVM
                           {
                               Id = c.Id.ToString(),
                               FileName = c.FileName,
                               PathOrContainerName = c.Path,
                               Storage = c.Storage,
                               StaffId = c.Id.ToString()

                           }).ToList();

            var totalCount = files.Count(); 

            return Task.FromResult(new GetFileListByStaffIdResponse
            {
                TotalCount = totalCount,
                Files = files
            });
        }
    }
}
