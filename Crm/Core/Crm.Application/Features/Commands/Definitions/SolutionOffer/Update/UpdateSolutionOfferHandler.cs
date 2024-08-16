using AutoMapper;
using GCrm.Application.Repositories.ReadRepository;
using GCrm.Application.Repositories.WriteRepository;
using MediatR;
using Utilities.Core.UtilityApplication.Enums;

namespace GCrm.Application.Features.Commands.Definitions.SolutionOffer.Update
{
    public class UpdateSolutionOfferHandler : IRequestHandler<UpdateSolutionOfferRequest, UpdateSolutionOfferResponse>
    {
        readonly ISolutionOfferWriteRepository  _solutionOfferWriteRepository;
        readonly ISolutionOfferReadRepository  _solutionOfferReadRepository;
        readonly IMapper _mapper;

        public UpdateSolutionOfferHandler(ISolutionOfferWriteRepository solutionOfferWriteRepository, ISolutionOfferReadRepository solutionOfferReadRepository, IMapper mapper)
        {
            _solutionOfferWriteRepository = solutionOfferWriteRepository;
            _solutionOfferReadRepository = solutionOfferReadRepository;
            _mapper = mapper;
        }

        public async  Task<UpdateSolutionOfferResponse> Handle(UpdateSolutionOfferRequest request, CancellationToken cancellationToken)
        {
            var SolutionOffer = await _solutionOfferReadRepository.GetByIdAsync(request.Id);
            SolutionOffer = _mapper.Map(request, SolutionOffer);
            await _solutionOfferWriteRepository.SaveAsync();

            var updatedResponse = _mapper.Map<UpdateSolutionOfferResponse>(SolutionOffer);
            updatedResponse.Message = CommandResponseMessage.UpdatedSuccess.ToString();

            return updatedResponse;
        }
    }
}
