using AutoMapper;
using GCrm.Application.Repositories.ReadRepository;
using GCrm.Application.Repositories.WriteRepository;
using MediatR;
using Utilities.Core.UtilityApplication.Enums;

namespace GCrm.Application.Features.Commands.Definitions.CustomerSubject.Update
{
    public class UpdateCustomerSubjectHandler : IRequestHandler<UpdateCustomerSubjectRequest, UpdateCustomerSubjectResponse>
    {
        readonly ICustomerSubjectWriteRepository _customerSubjectWriteRepository;
        readonly ICustomerSubjectReadRepository _customerSubjectReadRepository;
        readonly IMapper _mapper;

        public UpdateCustomerSubjectHandler(ICustomerSubjectWriteRepository customerSubjectWriteRepository, ICustomerSubjectReadRepository customerSubjectReadRepository, IMapper mapper)
        {
            _customerSubjectWriteRepository = customerSubjectWriteRepository;
            _customerSubjectReadRepository = customerSubjectReadRepository;
            _mapper = mapper;

        }
        public async Task<UpdateCustomerSubjectResponse> Handle(UpdateCustomerSubjectRequest request, CancellationToken cancellationToken)
        {
            var customerSubject = await _customerSubjectReadRepository.GetByIdAsync(request.Id);
            customerSubject = _mapper.Map(request, customerSubject);
            await _customerSubjectWriteRepository.SaveAsync();

            var updatedResponse = _mapper.Map<UpdateCustomerSubjectResponse>(customerSubject);
            updatedResponse.Message = CommandResponseMessage.UpdatedSuccess.ToString();

            return updatedResponse;
        }
    }
}
