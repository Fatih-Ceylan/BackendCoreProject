using GCharge.Application.Repositories.WriteRepository.Definitions;
using MediatR;
using Utilities.Core.UtilityApplication.Enums;

namespace GCharge.Application.Features.Commands.Definitions.ElectricitySalesPrice.Delete
{
    public class DeleteElectricitySalesPriceHandler : IRequestHandler<DeleteElectricitySalesPriceRequest, DeleteElectricitySalesPriceResponse>
    {
        readonly IElectricitySalesPriceWriteRepository _electricitySalesPriceWriteRepository;


        public DeleteElectricitySalesPriceHandler(IElectricitySalesPriceWriteRepository electricitySalesPriceWriteRepository)
        {
            _electricitySalesPriceWriteRepository = electricitySalesPriceWriteRepository;


        }
        public async Task<DeleteElectricitySalesPriceResponse> Handle(DeleteElectricitySalesPriceRequest request, CancellationToken cancellationToken)
        {
            await _electricitySalesPriceWriteRepository.SoftDeleteAsync(request.Id);
            await _electricitySalesPriceWriteRepository.SaveAsync();

            return new()
            {
                Message = CommandResponseMessage.DeletedSuccess.ToString(),
            };
        }
    }
}
