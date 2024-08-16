using AutoMapper;
using GCrm.Application.Repositories.ReadRepository;
using GCrm.Application.Repositories.WriteRepository;
using MediatR;
using Utilities.Core.UtilityApplication.Enums;

namespace GCrm.Application.Features.Commands.Definitions.CustomerCategory.Update
{
    public class UpdateCustomerCategoryHandler : IRequestHandler<UpdateCustomerCategoryRequest, UpdateCustomerCategoryResponse>
    {
        readonly ICustomerCategoryWriteRepository _customerCategoryWriteRepository;
        readonly ICustomerCategoryReadRepository _customerCategoryReadRepository;
        readonly IMapper _mapper;
        public UpdateCustomerCategoryHandler(ICustomerCategoryWriteRepository customerCategoryWriteRepository, ICustomerCategoryReadRepository customerCategoryReadRepository, IMapper mapper)
        {
            _customerCategoryWriteRepository = customerCategoryWriteRepository;
            _customerCategoryReadRepository = customerCategoryReadRepository;
            _mapper = mapper;
        }

        public async Task<UpdateCustomerCategoryResponse> Handle(UpdateCustomerCategoryRequest request, CancellationToken cancellationToken)
        {
            var customercategories = await _customerCategoryReadRepository.GetByIdAsync(request.Id);
            customercategories = _mapper.Map(request, customercategories);
            await _customerCategoryWriteRepository.SaveAsync();

            var updatedResponse = _mapper.Map<UpdateCustomerCategoryResponse>(customercategories);
            updatedResponse.Message = CommandResponseMessage.UpdatedSuccess.ToString();

            return updatedResponse;
        }
    }
}
