using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Application.Dtos;

namespace DuyA.Admin.UserOtps
{
    public class UserOtpDto : EntityDto<int>
    {
        public int UserId { get; set; }
        public string UserCode { get; set; }
        public string OtpCode { get; set; }
        public DateTime? DateActive { get; set; }
        public DateTime? DateExpired { get; set; }
        public int? TimeActive { get; set; }
        public bool? IsOtp { get; set; }
        public DateTime? DateCreated { get; set; }
    }
}
