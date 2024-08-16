using AutoMapper;
using GCrm.Application.Repositories.WriteRepository;
using MediatR;
using Utilities.Core.UtilityApplication.Enums;
using T = BaseProject.Domain.Entities.GCrm.Definitions.ActivitiesManagement.Activities;



namespace GCrm.Application.Features.Commands.Definitions.CustomerActivitySubject.Create
{
    public class CreateCustomerActivitySubjectHandler : IRequestHandler<CreateCustomerActivitySubjectRequest, CreateCustomerActivitySubjectResponse>
    {
        readonly ICustomerActivitySubjectWriteRepository _customerActivitySubjectWriteRepository;
        readonly IMapper _mapper;

        public CreateCustomerActivitySubjectHandler(ICustomerActivitySubjectWriteRepository  customerActivitySubjectWriteRepository, IMapper mapper)
        {
            _customerActivitySubjectWriteRepository = customerActivitySubjectWriteRepository;
            _mapper = mapper;
        }

        public async Task<CreateCustomerActivitySubjectResponse> Handle(CreateCustomerActivitySubjectRequest request, CancellationToken cancellationToken)
        {
            var customeractivitysubject = _mapper.Map<T.CustomerActivitySubject>(request);
            customeractivitysubject = await _customerActivitySubjectWriteRepository.AddAsync(customeractivitysubject);
            await _customerActivitySubjectWriteRepository.SaveAsync();

            var createdResponse = _mapper.Map<CreateCustomerActivitySubjectResponse>(customeractivitysubject);
            createdResponse.Message = CommandResponseMessage.AddedSuccess.ToString();

            return createdResponse;


        }
    }
}
