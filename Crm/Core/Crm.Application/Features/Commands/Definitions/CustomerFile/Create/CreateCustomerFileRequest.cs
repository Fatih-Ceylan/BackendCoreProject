using MediatR;
using Microsoft.AspNetCore.Http;

namespace GCrm.Application.Features.Commands.Definitions.CustomerFile.Create
{
    public class CreateCustomerFileRequest : IRequest<CreateCustomerFileResponse>
    {
        public string Id { get; set; }
        public IFormFileCollection? File { get; set; }
    }
}
