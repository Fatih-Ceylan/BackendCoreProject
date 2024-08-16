using AutoMapper;
using BaseProject.Application.Repositories.ReadRepository.Definitions;
using BaseProject.Application.Repositories.WriteRepository.Definitions;
using MediatR;
using Utilities.Core.UtilityApplication.Abstractions.Services.Encryption.Aes256;
using Utilities.Core.UtilityApplication.Enums;

namespace BaseProject.Application.Features.Commands.Definitions.MailCredential.Update
{
    public class UpdateMailCredentialHandler : IRequestHandler<UpdateMailCredentialRequest, UpdateMailCredentialResponse>
    {
        readonly IMapper _mapper;
        readonly IMailCredentialReadRepository _mailCredentialReadRepository;
        readonly IMailCredentialWriteRepository _mailCredentialWriteRepository;
        readonly IAes256Service _aes256Service;

        public UpdateMailCredentialHandler(IMapper mapper, IMailCredentialReadRepository mailCredentialReadRepository, IMailCredentialWriteRepository mailCredentialWriteRepository, IAes256Service aes256Service)
        {
            _mapper = mapper;
            _mailCredentialReadRepository = mailCredentialReadRepository;
            _mailCredentialWriteRepository = mailCredentialWriteRepository;
            _aes256Service = aes256Service;
        }

        public async Task<UpdateMailCredentialResponse> Handle(UpdateMailCredentialRequest request, CancellationToken cancellationToken)
        {
            var mailCredential = await _mailCredentialReadRepository.GetByIdAsync(request.Id);
            request.FromPassword = _aes256Service.Encrypt(request.FromPassword);
            mailCredential = _mapper.Map(request, mailCredential);
            _mailCredentialWriteRepository.Update(mailCredential);
            await _mailCredentialWriteRepository.SaveAsync();

            var updatedResponse = _mapper.Map<UpdateMailCredentialResponse>(mailCredential);
            updatedResponse.Message = CommandResponseMessage.UpdatedSuccess.ToString();

            return updatedResponse;
        }
    }
}