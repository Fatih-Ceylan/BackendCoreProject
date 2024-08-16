using GControl.Application.Repositories.ReadRepository;
using MediatR;

namespace GControl.Application.Features.Queries.Definitions.EmployeeFile.GetFileListByEmployeeId
{
    public class GetFileListByEmployeeIdHandler : IRequestHandler<GetFileListByEmployeeIdRequest, GetFileListByEmployeeIdResponse>
    {
        readonly IEmployeeFileReadRepository _employeeFileReadRepository;

        public GetFileListByEmployeeIdHandler(IEmployeeFileReadRepository employeeFileReadRepository)
        {
            _employeeFileReadRepository = employeeFileReadRepository;
        }

        public async Task<GetFileListByEmployeeIdResponse> Handle(GetFileListByEmployeeIdRequest request, CancellationToken cancellationToken)
        {
            //var files = _employeeFileReadRepository
            //               .GetWhere(c => c.EmployeeId == Guid.Parse(request.Id), false)
            //               .Select(c => new EmployeeFileVM
            //               {
            //                   Id = c.Id.ToString(),
            //                   FileName = c.FileName,
            //                   PathOrContainerName = c.Path,
            //                   Storage = c.Storage,

            //               }).ToList();

            //var totalCount = files.Count();

            //return Task.FromResult(new GetFileListByEmployeeIdResponse
            //{
            //    TotalCount = totalCount,
            //    Files = files
            //});

            return new();
        }
    }
}
