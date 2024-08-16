using MediatR;

namespace Card.Application.Features.Commands.Definitions.StaffContact.Delete
{
    public class DeleteStaffContactRequest : IRequest<DeleteStaffContactResponse>
    {
        public string Id { get; set; }
    }
}
