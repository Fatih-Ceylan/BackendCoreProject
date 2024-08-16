using MediatR;
using Microsoft.AspNetCore.Http;

namespace Platform.Application.Features.Commands.Definitions.Files.CompanyFile.Create
{
    public class CreateCompanyFileRequest : IRequest<CreateCompanyFileResponse>
    {
        public string Id { get; set; }
        public IFormFileCollection? Files { get; set; }
    }
}
