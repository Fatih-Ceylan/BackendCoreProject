using MediatR;
using Microsoft.AspNetCore.Http;

namespace GControl.Application.Features.Commands.Definitions.EmployeeFile.Create
{
    public class CreateEmployeeFileRequest : IRequest<CreateEmployeeFileResponse>
    {
        public string EmployeeId { get; set; }
        public string BaseProjectCompanyId { get; set; }
        public string BaseProjectBranchId { get; set; }
        public IFormFileCollection Files { get; set; }
    }

}
