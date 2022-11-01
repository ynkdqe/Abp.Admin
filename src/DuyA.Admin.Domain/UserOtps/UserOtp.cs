using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Entities;

namespace DuyA.Admin.UserOtps
{
    public partial class UserOtp : Entity<int>
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
