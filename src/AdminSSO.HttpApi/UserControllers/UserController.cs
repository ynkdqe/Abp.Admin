using AdminSSO.Dtos;
using AdminSSO.Users;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using Volo.Abp;

namespace AdminSSO.UserControllers
{
    [Area(AdminSSORemoteServiceConsts.ModuleName)]
    [RemoteService(Name = AdminSSORemoteServiceConsts.RemoteServiceName)]
    [Route("api/user")]
    public class UserController : AdminSSOController, IUserAppService
    {
        IUserAppService _userAppService;
        public UserController(IUserAppService userAppService)
        {
            _userAppService = userAppService;
        }

        [HttpGet]
        [Route("auto-generate-info-user")]
        public Task<AutoGenerateInfoUserDto> AutoGenerateInfoUser(string fullName)
        {
            return _userAppService.AutoGenerateInfoUser(fullName);
        }

        [HttpPost]
        public async Task<CreateUserResponseDto> Create(UserInputCreateDto createDto)
        {
            return await _userAppService.Create(createDto);
        }
        [HttpGet]
        [Authorize]
        [Route("get-list")]
        public async Task<CustomPagedResultDto<UserDto>> GetList(UserInputSearchDto searchDto)
        {
            return await _userAppService.GetList(searchDto);
        }
        [HttpGet]
        [Authorize()]
        [Route("get-by-id")]
        public async Task<UserDto> GetUserById(int Id)
        {
            return await _userAppService.GetUserById(Id);
        }
        [HttpGet]
        [Authorize()]
        [Route("get-profile")]
        public Task<UserProfileDto> GetUserProfile(string id)
        {
            var user = AuthenticationShared.GetUserFromTokenJWT(id);
            return null;
        }

        [HttpPost]
        [Route("login")]
        public async Task<LoginResponse> Login(string userName, string password)
        {
            return await _userAppService.Login(userName, password);
        }

        //[HttpPost]
        //public Task<LoginResponse> Login(string userName, string password)
        //{
        //    throw new NotImplementedException();
        //}

        [HttpPut]
        [Authorize]
        public Task<UserDto> Update(UserInputUpdateDto updateDto)
        {
            throw new NotImplementedException();
        }
    }
}
