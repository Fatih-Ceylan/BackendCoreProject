using GControl.Application.Repositories.ReadRepository;
using GControl.Application.VMs.Definitions;
using MediatR;

namespace GControl.Application.Features.Queries.Definitions.EmployeeFile.GetById
{
    public class GetByIdEmployeeFileHandler : IRequestHandler<GetByIdEmployeeFileRequest, GetByIdEmployeeFileResponse>
    {
        readonly IEmployeeFileReadRepository _employeeFileReadRepository;

        public GetByIdEmployeeFileHandler(IEmployeeFileReadRepository employeeFileReadRepository)
        {
            _employeeFileReadRepository = employeeFileReadRepository;
        }

        public async Task<GetByIdEmployeeFileResponse> Handle(GetByIdEmployeeFileRequest request, CancellationToken cancellationToken)
        {
            var file = _employeeFileReadRepository
                           .GetWhere(c => c.Id == Guid.Parse(request.Id), false)
                           .Select(c => new EmployeeFileVM
                           {
                               Id = c.Id.ToString(),
                               FileName = c.FileName,
                               PathOrContainerName = c.Path,
                               Storage = c.Storage,
                               //BaseProjectBranchId = c.BaseProjectBranchId.ToString(),
                               //BaseProjectCompanyId = c.BaseProjectCompanyId.ToString(),

                           }).FirstOrDefault();

            return new()
            {
                File = file
            };
        }
    }
}
