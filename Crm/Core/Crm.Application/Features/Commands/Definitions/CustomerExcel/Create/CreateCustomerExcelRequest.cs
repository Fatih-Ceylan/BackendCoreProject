using MediatR;

namespace GCrm.Application.Features.Commands.Definitions.CustomerExcel.Create
{
    public  class CreateCustomerExcelRequest : IRequest<CreateCustomerExcelResponse>
    {
        public string FilePath { get; set; }

    }
}
