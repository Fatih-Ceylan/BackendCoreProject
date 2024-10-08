﻿using MediatR;
using Utilities.Core.UtilityApplication.RequestParameters;

namespace GControl.Application.Features.Queries.Definitions.Employee.DownloadQrCode
{
    public class DownloadQrCodeRequest : Pagination, IRequest<DownloadQrCodeResponse>
    {
        public string Id { get; set; }
    }
}
