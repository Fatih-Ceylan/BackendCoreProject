using AutoMapper;
using GCrm.Application.Repositories.ReadRepository;
using GCrm.Application.Repositories.WriteRepository;
using MediatR;
using Utilities.Core.UtilityApplication.Enums;

namespace GCrm.Application.Features.Commands.Definitions.CustomerProject.Update
{
    public class UpdateCustomerProjectHandler : IRequestHandler<UpdateCustomerProjectRequest, UpdateCustomerProjectResponse>
    {
        readonly ICustomerProjectWriteRepository _customerProjectWriteRepository;
        readonly ICustomerProjectReadRepository _customerProjectReadRepository;
        readonly IMapper _mapper;

        public UpdateCustomerProjectHandler(ICustomerProjectWriteRepository customerProjectWriteRepository, ICustomerProjectReadRepository customerProjectReadRepository, IMapper mapper)
        {
            _customerProjectWriteRepository = customerProjectWriteRepository;
            _customerProjectReadRepository = customerProjectReadRepository;
            _mapper = mapper;
        }

        public async Task<UpdateCustomerProjectResponse> Handle(UpdateCustomerProjectRequest request, CancellationToken cancellationToken)
        {
            var customerproject = await _customerProjectReadRepository.GetByIdAsync(request.Id);
            customerproject = _mapper.Map(request, customerproject);
            await _customerProjectWriteRepository.SaveAsync();

            var updatedResponse = _mapper.Map<UpdateCustomerProjectResponse>(customerproject);
            updatedResponse.Message = CommandResponseMessage.UpdatedSuccess.ToString();

            return updatedResponse;
        }
    }
}
