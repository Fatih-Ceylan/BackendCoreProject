using MediatR;
using OfficeOpenXml;

namespace GCrm.Application.Features.Commands.Definitions.CustomerExcel.Create
{
    public class CreateCustomerExcelHandler : IRequestHandler<CreateCustomerExcelRequest, CreateCustomerExcelResponse>
    {
        private object filePath;
        readonly IMediator _mediator;
        public CreateCustomerExcelHandler(IMediator mediator)
        {
            _mediator = mediator;
        }
        public async  Task<CreateCustomerExcelResponse> Handle(CreateCustomerExcelRequest request, CancellationToken cancellationToken)
        {
            using (var package = new ExcelPackage(new FileInfo(request.FilePath)))
            {
                var command = new CreateCustomerExcelRequest { FilePath = (string)filePath };
                var result = await _mediator.Send(command);
                return result;
              
            }
        }
    }
}
