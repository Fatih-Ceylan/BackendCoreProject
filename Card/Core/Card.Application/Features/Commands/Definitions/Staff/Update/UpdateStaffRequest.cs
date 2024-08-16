using MediatR;
using Microsoft.AspNetCore.Http;

namespace Card.Application.Features.Commands.Definitions.Staff.Update
{
    public class UpdateStaffRequest : IRequest<UpdateStaffResponse>
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Title { get; set; }
        public string? ProfilePicturePath { get; set; }
        public string? Description { get; set; }
        public string CompanyId { get; set; }
        public string BranchId { get; set; }
        public IFormFileCollection? Files { get; set; }
    }
}
