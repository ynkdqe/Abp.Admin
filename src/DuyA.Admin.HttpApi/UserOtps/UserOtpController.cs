
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Xml.Linq;
using Volo.Abp;

namespace DuyA.Admin.UserOtps
{
    [Area(AdminRemoteServiceConsts.ModuleName)]
    [RemoteService(Name = AdminRemoteServiceConsts.RemoteServiceName)]
    [Route("api/user/user-otp")]
    public class UserOtpController : ControllerBase, IUserOtpAppService
    {
        private readonly IUserOtpAppService _userOtpAppService;
        public UserOtpController(IUserOtpAppService userOtpAppService)
        {
            _userOtpAppService = userOtpAppService;
        }
        [HttpGet]
        public Task<UserOtpDto> GetByIdAsync(int id, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        [HttpGet]
        [Route("GetList2")]
        public Task<List<UserOtpDto>> GetListAsync(CancellationToken cancellationToken = default)
        {
            return _userOtpAppService.GetListAsync();
        }
    }
}
