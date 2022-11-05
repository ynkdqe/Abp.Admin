using AdminSSO.UseroOtps;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using Volo.Abp;

namespace AdminSSO.Users
{
    [Area(AdminSSORemoteServiceConsts.ModuleName)]
    [RemoteService(Name = AdminSSORemoteServiceConsts.RemoteServiceName)]
    [Route("api/user/user-profile")]
    public class UserController : ControllerBase, IUserAppService
    {
        private readonly IUserAppService _userAppService;
        public UserController(IUserAppService userAppService)
        {
            _userAppService = userAppService;
        }
        [HttpGet]
        [Route("get-list")]
        public Task<List<UserDto>> GetList()
        {
            return _userAppService.GetList();
        }
        [HttpGet]
        [Route("get-by-id")]
        public Task<UserDto> GetUserById(int Id)
        {
            return _userAppService.GetUserById(Id);
        }
    }
}
