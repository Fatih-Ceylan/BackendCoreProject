using MediatR;

namespace BaseProject.Application.Features.Commands.Definitions.District.Delete
{
    public class DeleteDistrictRequest: IRequest<DeleteDistrictResponse>
    {
        public int Id { get; set; }
    }
}