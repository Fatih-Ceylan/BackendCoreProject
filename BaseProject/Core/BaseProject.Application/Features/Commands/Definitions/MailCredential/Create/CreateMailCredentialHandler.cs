using AutoMapper;
using BaseProject.Application.Repositories.WriteRepository.Definitions;
using MediatR;
using Utilities.Core.UtilityApplication.Abstractions.Services.Encryption.Aes256;
using Utilities.Core.UtilityApplication.Enums;
using T = BaseProject.Domain.Entities.Definitions;

namespace BaseProject.Application.Features.Commands.Definitions.MailCredential.Create
{
    public class CreateMailCredentialHandler : IRequestHandler<CreateMailCredentialRequest, CreateMailCredentialResponse>
    {
        readonly IMapper _mapper;
        readonly IMailCredentialWriteRepository _mailCredentialWriteRepository;
        readonly IAes256Service _aes256Service;

        public CreateMailCredentialHandler(IMapper mapper, IMailCredentialWriteRepository mailCredentialWriteRepository, IAes256Service aes256Service)
        {
            _mapper = mapper;
            _mailCredentialWriteRepository = mailCredentialWriteRepository;
            _aes256Service = aes256Service;
        }

        public async Task<CreateMailCredentialResponse> Handle(CreateMailCredentialRequest request, CancellationToken cancellationToken)
        {
            request.FromPassword = _aes256Service.Encrypt(request.FromPassword);
            T.MailCredential mailCredential = _mapper.Map<T.MailCredential>(request);

            mailCredential = await _mailCredentialWriteRepository.AddAsync(mailCredential);
            await _mailCredentialWriteRepository.SaveAsync();

            var createdResponse = _mapper.Map<CreateMailCredentialResponse>(mailCredential);
            createdResponse.Message = CommandResponseMessage.AddedSuccess.ToString();

            return createdResponse;
        }
    }
}