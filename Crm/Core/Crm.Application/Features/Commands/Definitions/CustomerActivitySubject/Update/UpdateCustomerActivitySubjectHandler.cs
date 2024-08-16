using AutoMapper;
using GCrm.Application.Repositories.ReadRepository;
using GCrm.Application.Repositories.WriteRepository;
using MediatR;
using Utilities.Core.UtilityApplication.Enums;

namespace GCrm.Application.Features.Commands.Definitions.CustomerActivitySubject.Update
{
    public  class UpdateCustomerActivitySubjectHandler : IRequestHandler<UpdateCustomerActivitySubjectRequest, UpdateCustomerActivitySubjectResponse>
    {
        readonly ICustomerActivitySubjectReadRepository  _customerActivitySubjectReadRepository;
        readonly ICustomerActivitySubjectWriteRepository  _customerActivitySubjectWriteRepository;
        readonly IMapper _mapper;

        public UpdateCustomerActivitySubjectHandler(ICustomerActivitySubjectReadRepository customerActivitySubjectReadRepository, ICustomerActivitySubjectWriteRepository customerActivitySubjectWriteRepository, IMapper mapper)
        {
            _customerActivitySubjectReadRepository = customerActivitySubjectReadRepository;
            _customerActivitySubjectWriteRepository = customerActivitySubjectWriteRepository;
            _mapper = mapper;
        }

        public async  Task<UpdateCustomerActivitySubjectResponse> Handle(UpdateCustomerActivitySubjectRequest request, CancellationToken cancellationToken)
        {
            var customeractivitysubject = await _customerActivitySubjectReadRepository.GetByIdAsync(request.Id);
            customeractivitysubject = _mapper.Map(request, customeractivitysubject);
            await _customerActivitySubjectWriteRepository.SaveAsync();

            var updatedResponse = _mapper.Map<UpdateCustomerActivitySubjectResponse>(customeractivitysubject);
            updatedResponse.Message = CommandResponseMessage.UpdatedSuccess.ToString();

            return updatedResponse;
        }
    }
}
