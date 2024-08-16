using MediatR;

namespace BaseProject.Application.Features.Queries.Definitions.District.GetById
{
    public class GetByIdDistrictRequest: IRequest<GetByIdDistrictResponse>
    {
        public int Id { get; set; }
    }
}