using MediatR;

namespace Card.Application.Features.Queries.Definitions.StaffContact.GetById
{
    public class GetByIdStaffContactRequest : IRequest<GetByIdStaffContactResponse>
    {
        public string Id { get; set; }
    }
}
