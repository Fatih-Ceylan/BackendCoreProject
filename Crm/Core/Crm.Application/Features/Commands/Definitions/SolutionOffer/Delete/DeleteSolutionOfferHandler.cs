using GCrm.Application.Repositories.WriteRepository;
using MediatR;
using Utilities.Core.UtilityApplication.Enums;

namespace GCrm.Application.Features.Commands.Definitions.SolutionOffer.Delete
{
    public class DeleteSolutionOfferHandler : IRequestHandler<DeleteSolutionOfferRequest, DeleteSolutionOfferResponse>
    {
        readonly ISolutionOfferWriteRepository  _solutionOfferWriteRepository;
        
        public DeleteSolutionOfferHandler(ISolutionOfferWriteRepository solutionOfferWriteRepository)
        {
            _solutionOfferWriteRepository= solutionOfferWriteRepository;

        }
        public async  Task<DeleteSolutionOfferResponse> Handle(DeleteSolutionOfferRequest request, CancellationToken cancellationToken)
        {
            await _solutionOfferWriteRepository.SoftDeleteAsync(request.Id);
            await _solutionOfferWriteRepository.SaveAsync();

            return new()
            {
                Message = CommandResponseMessage.DeletedSuccess.ToString(),
            };
        }
    }
}
