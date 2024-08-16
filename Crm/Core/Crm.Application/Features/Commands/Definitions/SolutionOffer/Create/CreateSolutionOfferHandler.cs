using AutoMapper;
using GCrm.Application.Repositories.WriteRepository;
using MediatR;
using Utilities.Core.UtilityApplication.Enums;
using T = BaseProject.Domain.Entities.GCrm.Definitions.OpportunityManagement.Opportunity;


namespace GCrm.Application.Features.Commands.Definitions.SolutionOffer.Create
{
    public class CreateSolutionOfferHandler : IRequestHandler<CreateSolutionOfferRequest, CreateSolutionOfferResponse>
    {
        readonly ISolutionOfferWriteRepository _solutionOfferWriteRepository ;
        readonly IMapper _mapper;

        public CreateSolutionOfferHandler(ISolutionOfferWriteRepository solutionOfferWriteRepository, IMapper mapper)
        {
            _solutionOfferWriteRepository = solutionOfferWriteRepository;
            _mapper = mapper;
        }

        public async  Task<CreateSolutionOfferResponse> Handle(CreateSolutionOfferRequest request, CancellationToken cancellationToken)
        {
           T.SolutionOffer SolutionOffer = _mapper.Map<T.SolutionOffer>(request);

            SolutionOffer = await _solutionOfferWriteRepository.AddAsync(SolutionOffer);
            await _solutionOfferWriteRepository.SaveAsync();

            var createdResponse = _mapper.Map<CreateSolutionOfferResponse>(SolutionOffer);
            createdResponse.Message = CommandResponseMessage.AddedSuccess.ToString();

            return createdResponse;
        }
    }
}
