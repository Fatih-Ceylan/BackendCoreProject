using MediatR;
using Utilities.Core.UtilityApplication.RequestParameters;

namespace BaseProject.Application.Features.Queries.Definitions.MailCredential.GetAll
{
    public class GetAllMailCredentialRequest: Pagination,IRequest<GetAllMailCredentialResponse>
    {
        
    }
}
