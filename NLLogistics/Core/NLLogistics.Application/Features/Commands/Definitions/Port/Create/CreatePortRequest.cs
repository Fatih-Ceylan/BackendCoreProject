using MediatR;

namespace NLLogistics.Application.Features.Commands.Definitions.Port.Create
{
    public class CreatePortRequest: IRequest<CreatePortResponse>
    {
        public string Code { get; set; }

        public string Name { get; set; }

        public int? CountryId { get; set; }

    }
}