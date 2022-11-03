using AdminSSO.UseroOtps;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using Volo.Abp;

namespace AdminSSO.UserOtps
{
    [Area(AdminSSORemoteServiceConsts.ModuleName)]
    [RemoteService(Name = AdminSSORemoteServiceConsts.RemoteServiceName)]
    [Route("api/user/user-otp")]
    public class UserOtpController : ControllerBase, IUserOtpAppService
    {
        private readonly IUserOtpAppService _userOtpAppService;
        public UserOtpController(IUserOtpAppService userOtpAppService)
        {
            _userOtpAppService = userOtpAppService;
        }
    }
}
