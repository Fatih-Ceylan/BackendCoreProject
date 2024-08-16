using MediatR;

namespace GControl.Application.Features.Queries.Definitions.EmployeeLabel.LabelGroup.GetById
{
    public class GetByIdLabelGroupRequest : IRequest<GetByIdLabelGroupResponse>
    {
        public string Id { get; set; }
    }
}
