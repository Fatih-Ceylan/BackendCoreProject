using MediatR;
using Microsoft.AspNetCore.Http;

namespace Card.Application.Features.Commands.Definitions.Staff.Create
{
    public class CreateStaffRequest : IRequest<CreateStaffResponse>
    {
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Title { get; set; }
        public string PhoneNumber { get; set; }
        public string? Description { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string CompanyId { get; set; }
        public string BranchId { get; set; }
        public IFormFileCollection? Files { get; set; }
    }
}