using MediatR;

namespace Card.Application.Features.Queries.Definitions.StaffField.GetById
{
    public class GetByIdStaffFieldRequest : IRequest<GetByIdStaffFieldResponse>
    {
        public string Id { get; set; }
    }
} 
