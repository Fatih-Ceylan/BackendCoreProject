﻿using Card.Application.VMs;

namespace Card.Application.Features.Queries.Definitions.Staff.MobileGetByIdStaffInfo
{
    public class MobileGetByIdStaffInfoResponse
    {
        public MobileRelatedListByStaffIdVM RelatedList { get; set; }
        public string Message { get; set; }
        public string? StatusCode { get; set; }
        public int SocialMediaUrlListCount { get; set; }
    }
}
